import { HubConnectionBuilder } from '@microsoft/signalr';

const connection = new HubConnectionBuilder()
    .withUrl("https://localhost:5001/hubs/chat")
    .withAutomaticReconnect()
    .build();

export default connection;
