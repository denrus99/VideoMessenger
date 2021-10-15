import React, { useState, useEffect, useRef } from 'react';
import { useParams } from "react-router";
import { HubConnectionBuilder } from '@microsoft/signalr';
/*import connection from '../hooks/useSignalR'*/

export default function Room() {
    const { id: roomId } = useParams();
    const [connection, setConnection] = useState(null);
    const peerConnections = useRef({});
    const sendChannels = useRef({});
    let clients = [];
    const configuration = { 'iceServers': [{ 'urls': 'stun:stun.l.google.com:19302' }] }

    useEffect(() => {
        const connection = new HubConnectionBuilder()
            .withUrl("https://localhost:5001/hubs/chat")
            .withAutomaticReconnect()
            .build();

        setConnection(connection);
    }, [])

    useEffect(() => {
        if (connection) {
            connection.start().then(() => {
                connection.send('JoinRoom', roomId);

                connection.on('Created', rooms => {
                    console.log('Комната создана!');
                });
                connection.on('Joined', rooms => {
                    console.log('Зашел в комнату!');
                });
                connection.on('ReceiveOffer', (clientId, offer) => {
                    console.log('Пришел Offer');
                    SetRemote(clientId, offer);
                    if (offer['type'] == 'offer') {
                        createAnswer(clientId);
                    }
                });
                connection.on('ReceiveIceCandidate', (clientId, candidate) => {
                    console.log('Пришел кандидат!');
                    peerConnections.current[clientId].addIceCandidate(candidate);
                });
                connection.on('JoinedNewClient', clientId => {
                    createPeerConnection(clientId);
                    createOffer(clientId);
                });
            });
        }
    }, [connection])

    function createPeerConnection(clientId) {
        clients.push(clientId);
        peerConnections.current[clientId] = new RTCPeerConnection(configuration);
        peerConnections.current[clientId].onicecandidate = function (event) {
            if (event.candidate) {
                AddIceCandidate(roomId, event.candidate);
            }
        };

        sendChannels.current[clientId] = peerConnections.current[clientId].createDataChannel("test");

        sendChannels.current[clientId].onopen = () => console.log('CHANNEL OPENED!');
        sendChannels.current[clientId].onmessage = (mes) => console.log(mes.data);
        sendChannels.current[clientId].onclose = () => console.log('CHANNEL CLOSED!');

        peerConnections.current[clientId].ondatachannel = (event) => {
            sendChannels.current[clientId] = event.channel;
        };
    }

    async function SetRemote(clientId, offer) {
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

    const onSubmit = (e) => {
        e.preventDefault();
        for (let i = 1; i <= clients.length; i++) {
            sendChannels.current[clients[i - 1]].send(`Сообщение ${i} клиенту`);
        }   
    }

    return (
        <div>
            Room
            <form
                onSubmit={onSubmit}>
                <button>Peers</button>
            </form>
        </div>
        
    );
}