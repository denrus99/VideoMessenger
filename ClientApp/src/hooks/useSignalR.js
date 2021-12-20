import { HubConnectionBuilder } from '@microsoft/signalr';
import { useEffect, useState } from 'react';

export default function useSignalR() {
    const [connection, setConnection] = useState(null);
    
    useEffect(() => {
        const connection = new HubConnectionBuilder()
            .withUrl("https://localhost:5001/hubs/roomHub")
            .withAutomaticReconnect()
            .build();
        setConnection(connection);
    }, []);

    return [connection];
}