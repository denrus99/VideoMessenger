import { connect } from 'net';
import React, { useState, useEffect } from 'react';
import { useHistory } from "react-router";
import { v4 } from 'uuid';
import { HubConnectionBuilder } from '@microsoft/signalr';
/*import connection from '../hooks/useSignalR'*/

export default function Lobby() {
    const history = useHistory();
    const [rooms, updateRooms] = useState([]);
    const [connection, setConnection] = useState(null);

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
                connection.send('GetCreatedRooms');
                connection.on('ReceiveCreatedRooms', rooms => {
                    updateRooms(rooms);
                });
            });
        }
    }, [connection]);

    return (
        <div>
            <h1>Доступные комнаты</h1>
            <ul>
                {rooms.map(roomId => (
                    <li key={ roomId }>
                        {roomId}
                        <button onClick={() => {
                            history.push(`/room/${roomId}`);
                        }}>Join</button>
                    </li>
                    ))}
            </ul>
            <button onClick={() => {
                history.push(`/room/${v4()}`)
            }}>Create New Room</button>
        </div>
    );
}