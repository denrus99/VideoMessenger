import React, { useState, useEffect} from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';
import VideoSend from './VideoSend';


const Video = () => {
    const [connection, setConnection] = useState(null);

    const configuration = { 'iceServers': [{ 'urls': 'stun:stun.l.google.com:19302' }] }
    const peerConnection = new RTCPeerConnection(configuration);

    peerConnection.onicecandidate = function (event) {
        if (event.candidate) {
            AddIceCandidate(event.candidate);
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
                console.log('Connected!');

                connection.on('ReceiveMessage', message => {
                    console.log('Пришел оффер!');
                    SetRemote(message);
                    if (message['type'] === 'offer') { 
                        Answer();
                    }
                });

                connection.on('ReceiveIceCandidate', candidate => {
                    
                    console.log('Пришел кандидат!');
                    peerConnection.addIceCandidate(candidate);
                });
            });
        }
    }, [connection])

    async function SetRemote(message) {
        const remoteDesc = new RTCSessionDescription(message);
        await peerConnection.setRemoteDescription(remoteDesc);
    }

    async function Answer() {
        const answer = await peerConnection.createAnswer();
        await peerConnection.setLocalDescription(answer);
        SendMessage(answer);
    }

    async function Offer() {
        const offer = await peerConnection.createOffer();
        await peerConnection.setLocalDescription(offer);
        SendMessage(offer);
    }

    const SendMessage = async (message) => {
        if (connection.connectionStarted) {
            try {
                await connection.send('SendMessage', message);
            }
            catch (e) {
                console.log(e);
            }
        }
        console.log('Вызвали SendMessage');
    }

    const AddIceCandidate = async (candidate) => {
        if (connection.connectionStarted) {
            try {
                await connection.send('AddIceCandidate', candidate);
            }
            catch (e) {
                console.log(e);
            }
        }
        console.log('Вызвали AddIceCandidate');
    }

    const onSubmit = (e) => {
        e.preventDefault();
        Offer();
    }
    const onSubmit2 = (e) => {
        e.preventDefault();
        sendChannel.send('MESSAGE');
    }

    return (
        <div>
            <VideoSend  peerConnection={peerConnection} SendMessage={SendMessage}></VideoSend>
            <form
                onSubmit={onSubmit}>
                <button>Send offer</button>
            </form>
            <form
                onSubmit={onSubmit2}>
                <button>Сообщение</button>
            </form>
        </div>
        );
};

export default Video;