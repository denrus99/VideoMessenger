import { useEffect, useState, useRef } from 'react';
import useSignalR from '../hooks/useSignalR'

const configuration = { 'iceServers': [{ 'urls': 'stun:stun.l.google.com:19302' }] }

export default function useWebRTC(roomId) {
    const [connection] = useSignalR();
    const [clients, updateClients] = useState([]);
    const peerConnections = useRef({});
    const sendChannels = useRef({});
    const localStream = useRef(null);
    const localVideo = useRef({});
    const remoteVideo = useRef({});

    useEffect(() => {
        if (connection) {
            connection.start().then(() => {
                navigator.mediaDevices.getUserMedia({ video: true, audio: true }).then((stream) => {
                    localVideo.current.srcObject = stream;
                    localStream.current = stream;
                    connection.send('JoinRoom', roomId);
                });

                connection.on('Created', e => {
                    console.log('Комната создана!');
                });
                connection.on('Joined', clients => {
                    updateClients(clients);
                    console.log('Зашел в комнату!');
                });
                connection.on('ReceiveOffer', (clientId, offer) => {
                    console.log('Пришел Offer');
                    setRemote(clientId, offer);
                    if (offer['type'] == 'offer') {
                        createAnswer(clientId);
                    }
                });
                connection.on('ReceiveIceCandidate', (clientId, candidate) => {
                    console.log('Пришел кандидат!');
                    peerConnections.current[clientId].addIceCandidate(candidate);
                });
                connection.on('JoinedNewClient', (clientId, clients) => {
                    createPeerConnection(clientId);
                    createOffer(clientId);
                });
            });
        }
    }, [connection])

    function createPeerConnection(clientId) {
        
        peerConnections.current[clientId] = new RTCPeerConnection(configuration);

        localStream.current.getTracks().forEach((track) => {
            peerConnections.current[clientId].addTrack(track, localStream.current);
        });

        peerConnections.current[clientId].onicecandidate = function (event) {
            if (event.candidate) {
                AddIceCandidate(roomId, event.candidate);
            }
        };

        peerConnections.current[clientId].ontrack = function (event) {
            remoteVideo.current.srcObject = event.streams[0];
        }

        sendChannels.current[clientId] = peerConnections.current[clientId].createDataChannel("test");

        sendChannels.current[clientId].onopen = () => console.log('CHANNEL OPENED!');
        sendChannels.current[clientId].onmessage = (mes) => console.log(mes.data);
        sendChannels.current[clientId].onclose = () => console.log('CHANNEL CLOSED!');

        peerConnections.current[clientId].ondatachannel = (event) => {
            sendChannels.current[clientId] = event.channel;
        };
    }

    async function setRemote(clientId, offer) {
        const remoteDesc = new RTCSessionDescription(offer);
        if (peerConnections.current[clientId] == null) {
            createPeerConnection(clientId);
        }
        await peerConnections.current[clientId].setRemoteDescription(remoteDesc);
    }

    async function createOffer(clientId) {
        const offer = await peerConnections.current[clientId].createOffer();
        await peerConnections.current[clientId].setLocalDescription(offer);
        SendOffer(clientId, offer);
    };

    async function createAnswer(clientId) {
        const answer = await peerConnections.current[clientId].createAnswer();
        await peerConnections.current[clientId].setLocalDescription(answer);
        SendOffer(clientId, answer);
    };

    const SendOffer = async (clientId, offer) => {
        if (connection.connectionStarted) {
            try {
                await connection.send('SendOffer', clientId, offer);
            }
            catch (e) {
                console.log(e);
            }
        }
        console.log('Вызвали SendOffer');
    }

    const AddIceCandidate = async (roomId, candidate) => {
        if (connection.connectionStarted) {
            try {
                await connection.send('AddIceCandidate', roomId, candidate);
            }
            catch (e) {
                console.log(e);
            }
        }
        console.log('Вызвали AddIceCandidate');
    }
    
    return [clients, localVideo, remoteVideo];
}