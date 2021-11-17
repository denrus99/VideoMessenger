import React, { useEffect } from 'react';
import { useParams } from "react-router";
import useNewWebRTC from '../hooks/useNewWebRtc.ts'

const Video = ({ stream }) => {
    const localVideo = React.createRef();

    useEffect(() => {
        if (localVideo.current)
            localVideo.current.srcObject = stream;
    }, [stream, localVideo]);

    return (
        <video style={{ height: 100, width: 100 }} ref={localVideo} autoPlay muted={true} />
    );
};

export default function Room() {
    const { id: roomId } = useParams();
    const [localStream, remoteStreams] = useNewWebRTC(roomId);

    return (
        <div>
            Room
            <Video stream={localStream}/>
            {remoteStreams.map((remoteStream) => <Video stream={remoteStream}/>)}
        </div>
    );
}