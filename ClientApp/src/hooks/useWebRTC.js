import { useEffect } from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';

export default function useWebRTC(roomId) {
    const [clients, updateClient] = useState([]);

    const peerConnections = useRef({});
    const localMediaStream = useRef(null);
    const peerMediaElements = useRef({});

    useEffect(() => {
        async function startCapture() {
            localMediaStream.current = await navigator.mediaDevices.getUserMedia({
                audio: true,
                video: {
                    width: 1280,
                    height: 720,
                }
            });   
        };
        startCapture();

    }, [roomId]);
}