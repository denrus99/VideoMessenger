import React, { useState, useEffect, useRef } from 'react';
import { useParams } from "react-router";
import useWebRTC from '../hooks/useWebRTC'

export default function Room() {
    const { id: roomId } = useParams();
    const [clients, localVideo, remoteVideo] = useWebRTC(roomId);


    //console.log(remoteVideos.current)
    //const onSubmit = (e) => {
    //    e.preventDefault();
    //    for (let i = 1; i <= clients.length; i++) {
    //        sendChannels.current[clients[i - 1]].send(`Сообщение ${i} клиенту`);
    //    }
    //}   

    return (
        <div>
            Room
            <video autoPlay playsInline muted ref={localVideo} />
            <video autoPlay playsInline ref={remoteVideo} />
            
            
            
            {/*<form*/}
            {/*    onSubmit={onSubmit}>*/}
            {/*    <button>Отправить сообщение клиентам</button>*/}
            {/*</form>*/}
        </div>
    );
}