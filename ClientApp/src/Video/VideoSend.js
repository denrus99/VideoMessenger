import React, { useState, useEffect } from 'react';

const VideoSend = (props) => {
    async function makeCall() {
        console.log(props.peerConnection.localDescription);
        console.log(props.peerConnection.remoteDescription);
    }

    const onSubmit = (e) => {
        e.preventDefault();
        makeCall();
    }


    return (
        <div>
        <form
            onSubmit={onSubmit}>
            <button>Peers</button>
        </form>
        </div>
    )
};

export default VideoSend;
