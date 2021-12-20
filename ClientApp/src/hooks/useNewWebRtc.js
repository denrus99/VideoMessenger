import { useEffect, useState} from 'react';
import {HubConnectionBuilder} from "@microsoft/signalr";

const configuration = { 'iceServers': [{ 'urls': 'stun:stun.l.google.com:19302' }] };

export default function useNewWebRTC(roomId) {
    const [signalConnection, setSignalConnection] = useState();
    const [localStream, setLocalStream] = useState();
    const [remoteStreams, setRemoteStreams] = useState([]);
    //TODO: Если не пригодится, можно убрать. В принципе все соединения хранятся в замыканиях.
    const [rtcConnections, setRtcConnections] = useState({});
    
    useEffect(() => {
        //Создаём сигнальный механизм
        const newSignalConnection = new HubConnectionBuilder()
            .withUrl("https://localhost:5001/hubs/roomHub")
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
            return ()=>{
                signalConnection.stop();
            }
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
                        setRemoteStreams(prevState => [...prevState, event.streams[0]]);
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

                setRtcConnections(prevState => ({...prevState, [clientId]: { connection: newRtcConnection, role: "Caller"}}));
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
                        setRemoteStreams(prevState => [...prevState, event.streams[0]]);
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
                                        setRtcConnections(prevState => ({...prevState, [clientId]: { connection: newRtcConnection, role: "Callee"}}));
                                    })
                            })
                    })
            });
            // Оповещаем остальных клиентов в комнате о том, что мы готовы общаться
            signalConnection.send('JoinRoom', roomId);
            return ()=>{
                debugger
                localStream.getTracks().forEach(m => m.stop());
                remoteStreams.forEach(m => m.getTracks().forEach(t=>t.stop()))
                setLocalStream(undefined);
                setRemoteStreams(undefined);
                setRtcConnections(undefined);
            }
        }
    }, [localStream]);
    
    return [localStream, remoteStreams];
}