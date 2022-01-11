import { useEffect, useState} from 'react';
import {HubConnectionBuilder} from "@microsoft/signalr";

const configuration = { 'iceServers': [{ 'urls': 'stun:stun.l.google.com:19302' }] };

export default function useNewWebRTC(roomId) {
    const [signalConnection, setSignalConnection] = useState();
    const [localStream, setLocalStream] = useState();
    const [remoteStreams, setRemoteStreams] = useState(new Map());
    //TODO: Если не пригодится, можно убрать. В принципе все соединения хранятся в замыканиях.
    const [rtcConnections, setRtcConnections] = useState(new Map());
    
    useEffect(() => {
        //Создаём сигнальный механизм
        const newSignalConnection = new HubConnectionBuilder()
            .withUrl("/hubs/roomHub")
            .withAutomaticReconnect()
            .build();
        setSignalConnection(newSignalConnection);
        return () => {
            if(signalConnection){
                signalConnection.stop();                
            }
        };
    }, []);
    
    useEffect( () => {
        //Запускаем сигнальный механизм
        if (signalConnection){
            signalConnection.start()
                .then(() => {
                    //Создаём локальный поток видео
                    navigator.mediaDevices.getUserMedia({ video: true, audio: true })
                        .then((stream) => {
                            setLocalStream(stream);
                        });
                });
        }
    }, [signalConnection]);
    
    useEffect(() => {
        //Добавляем обработку сообщения о новом клиенте
        if (signalConnection){
            signalConnection.on('JoinedNewClient', (clientId, clients) => {
                const newRtcConnection = new RTCPeerConnection(configuration);
                const tempClientId = clientId;
                
                signalConnection.on('ReceiveIceCandidate', (clientId, candidate) => {
                    if (clientId == tempClientId){
                        newRtcConnection.addIceCandidate(candidate);
                    }
                });
                //Получаем ответ от подключившегося клиента
                signalConnection.on('ReceiveAnswer', (clientId, answer) => {
                    if (clientId == tempClientId){
                        newRtcConnection.setRemoteDescription(answer);
                    }
                });
                
                //Добавляем локальный поток в новое соединение
                // @ts-ignore
                localStream.getTracks().forEach((track) => {
                    // @ts-ignore
                    newRtcConnection.addTrack(track, localStream);
                });
                
                newRtcConnection.onicecandidate = (event) => {
                    if (event.candidate){
                        // После создания оффера выкинуть iceCandidate, чтобы установить подключение
                        signalConnection.send('AddIceCandidate', roomId, event.candidate);                        
                    }
                };
                const tempStreams = [];
                newRtcConnection.ontrack = (event) => {
                    if (!tempStreams.some((stream) => stream === event.streams[0].id))
                    {
                        tempStreams.push(event.streams[0].id);
                        // При появлении нового потока в соединении установить его в качестве удаленного 
                        // @ts-ignore
                        setRemoteStreams(prevState => new Map(prevState.set(clientId, event.streams[0])));
                    }
                };
                newRtcConnection.onconnectionstatechange = (ev) => {
                    console.log(ev);
                    if (newRtcConnection.connectionState === "closed" || newRtcConnection.connectionState === "failed"){
                        let connection = [...rtcConnections.entries()].filter(v => {console.log(v); return v[1].connection === newRtcConnection})[0];
                        console.log(connection);
                        setRemoteStreams(prevState => {
                            let temp = prevState;
                            temp.delete(connection[0]);
                            return new Map(temp);
                        });
                        setRtcConnections(prevState => {
                            let temp = prevState;
                            temp.delete(connection[0]);
                            return new Map(temp);
                        });
                    }
                };
                //Создаём оффер
                newRtcConnection.createOffer()
                    .then((offer) => {
                        // Устанавливаем локальный SDP
                        newRtcConnection.setLocalDescription(offer)
                            .then(() => {
                                // Отправляем SDP 
                                signalConnection.send('SendOffer', clientId, newRtcConnection.localDescription);
                            });
                    });

                setRtcConnections(prevState => (new Map(prevState.set(clientId, { connection: newRtcConnection, role: "Caller"}))));
            });
            
            //Получаем оффер, создаём ответ и отправляем его инициатору
            signalConnection.on('ReceiveOffer', (clientId, offer) => {
                const newRtcConnection = new RTCPeerConnection(configuration);
                const tempClientId = clientId;
                
                signalConnection.on('ReceiveIceCandidate', (clientId, candidate) => {
                    if (clientId == tempClientId){
                        newRtcConnection.addIceCandidate(candidate);
                    }
                });
                // Добавляем локальный поток в соединение
                // @ts-ignore
                localStream.getTracks().forEach((track) => {
                    // @ts-ignore
                    newRtcConnection.addTrack(track, localStream);
                });
                const tempStreams = [];
                newRtcConnection.ontrack = (event) => {
                    if (!tempStreams.some((stream) => stream === event.streams[0].id))
                    {
                        tempStreams.push(event.streams[0].id);
                        // При появлении нового потока в соединении установить его в качестве удаленного 
                        // @ts-ignore
                        setRemoteStreams(prevState => new Map(prevState.set(clientId, event.streams[0])));
                    }
                };
                newRtcConnection.onconnectionstatechange = (ev) => {
                    console.log(ev);
                    if (newRtcConnection.connectionState === "closed" || newRtcConnection.connectionState === "failed"){
                        let connection = [...rtcConnections.entries()].filter(v => {console.log(v); return v[1].connection === newRtcConnection})[0];
                        debugger
                        console.log(connection);
                        setRemoteStreams(prevState => {
                            let temp = prevState;
                            temp.delete(connection[0]);
                            return new Map(temp);
                        });
                        setRtcConnections(prevState => {
                            let temp = prevState;
                            temp.delete(connection[0]);
                            return new Map(temp);
                        });
                    }
                };
                newRtcConnection.onicecandidate = (event) => {
                    if (event.candidate){
                        // После создания ответа выкинуть iceCandidate, чтобы установить подключение
                        signalConnection.send('AddIceCandidate', roomId, event.candidate);
                    }
                };
                // Устанавливаем полученный SDP в качестве удаленного
                newRtcConnection.setRemoteDescription(offer)
                    .then(() => {
                        // Создаем ответ на пришедший оффер 
                        newRtcConnection.createAnswer()
                            .then((answer) => {
                                newRtcConnection.setLocalDescription(answer)
                                    .then(() => {
                                        // Отправляем локальный SDP инициатору в качестве ответа на оффер
                                        signalConnection.send('SendAnswer', clientId, newRtcConnection.localDescription);
                                        setRtcConnections(prevState => (new Map(prevState.set(clientId, { connection: newRtcConnection, role: "Callee"}))));
                                    })
                            })
                    })
            });
            // Оповещаем остальных клиентов в комнате о том, что мы готовы общаться
            signalConnection.send('JoinRoom', roomId);
            signalConnection.on('ClientExit', function(clientId){
                remoteStreams.get(clientId).getTracks().forEach(m => m.stop());
                rtcConnections.get(clientId).connection.close();
                setRemoteStreams(prevState => {
                    let temp = prevState;
                    temp.delete(clientId);
                    return new Map(temp);
                });
                setRtcConnections(prevState => {
                    let temp = prevState;
                    temp.delete(clientId);
                    return new Map(temp);
                });
            })
            return function(){
                localStream.getTracks().forEach(m => m.stop());
                remoteStreams.forEach(m => m.getTracks().forEach(t=>t.stop()));
                [...rtcConnections].forEach((item) => {console.log(item); item[1].connection.close()});
                signalConnection.send('ExitRoom', roomId);
                signalConnection.stop();
                setLocalStream(undefined);
                setRemoteStreams(undefined);
                setRtcConnections(undefined);
            }
        }
    }, [localStream]);
    
    return [localStream, remoteStreams];
}