import React, { useState, useEffect } from 'react';
import { useHistory } from "react-router";
import { v4 } from 'uuid';
import useSignalR from '../hooks/useSignalR'

export default function Lobby() {
    const history = useHistory();
    const [connection] = useSignalR();
    const [rooms, updateRooms] = useState([]);

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
                    <li key={roomId}>
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