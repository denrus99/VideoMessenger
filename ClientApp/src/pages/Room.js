import React, { useState, useEffect, useRef } from 'react';
import { useParams } from "react-router";
import { HubConnectionBuilder } from '@microsoft/signalr';
/*import connection from '../hooks/useSignalR'*/

export default function Room() {
    const { id: roomId } = useParams();
    const [connection, setConnection] = useState(null);
    const peerConnections = useRef({});

    const configuration = { 'iceServers': [{ 'urls': 'stun:stun.l.google.com:19302' }] }
    const peerConnection = new RTCPeerConnection(configuration);

    peerConnection.onicecandidate = function (event) {
        if (event.candidate) {
            AddIceCandidate(roomId, event.candidate);
        }
    };

    let sendChannel = peerConnection.createDataChannel("test");

    sendChannel.onopen = () => console.log('CHANNEL OPENED!');
    sendChannel.onmessage = (mes) => console.log(mes.data);
    sendChannel.onclose = () => console.log('CHANNEL CLOSED!');

    peerConnection.ondatachannel = (event) => {
        sendChannel = event.channel;
    };

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
                    SetRemote(offer);
                    if (offer['type'] == 'offer') {
                        createAnswer(clientId);
                    }
                });
                connection.on('ReceiveIceCandidate', candidate => {
                    console.log('Пришел кандидат!');
                    peerConnection.addIceCandidate(candidate);
                });
                connection.on('JoinedNewClient', clientId => {
                    createOffer(clientId);
                });
            });
        }
    }, [connection])

    async function SetRemote(offer) {
        const remoteDesc = new RTCSessionDescription(offer);
        await peerConnection.setRemoteDescription(remoteDesc);
    }

    async function createOffer(clientId) {
        const offer = await peerConnection.createOffer();
        await peerConnection.setLocalDescription(offer);
        SendOffer(clientId, offer);
    };

    async function createAnswer(clientId) {
        const answer = await peerConnection.createAnswer();
        await peerConnection.setLocalDescription(answer);
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
        console.log(peerConnection.localDescription);
        console.log(peerConnection.remoteDescription);
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