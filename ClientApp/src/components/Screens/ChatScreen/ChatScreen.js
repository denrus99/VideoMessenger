import {React, useEffect, useState} from 'react';
import cs from './ChatScreen.module.css'
import MessageContainer from '../../MessageContainer/MessageContainer';
import SendMessageForm from '../../Forms/SendMessageForm';
import {HubConnectionBuilder} from "@microsoft/signalr";
import {getMessages} from "../../../utils/fetchs";

function ChatScreen(props) {
    const roomId = 'aaeb682b-f748-401c-b48a-7172d7b89858';
    const chatId = props.chat.ChatId;
    const [chatHub, setChatHub] = useState();
    const [messages, setMessages] = useState([]);

    useEffect(() => {
        const fetchMessages = async () => {
            try {
                const response = await getMessages(chatId);
                if (response.status) {
                    setMessages(response.messages);
                }
            } catch(e) {
                console.log(e);
            }
        }
        fetchMessages();
    }, [chatId]);

    useEffect(()=>{
        if (!chatHub && messages.length > 0)
        setChatHub(new HubConnectionBuilder()
            .withUrl("https://localhost:5001/hubs/chat")
            .withAutomaticReconnect()
            .build());
    }, [messages]);

    useEffect(()=>{
        if (chatHub){
            chatHub.start().then(() => {
                console.log(chatHub.state);
                chatHub.send("JoinChat", chatId, props.user.login);
                chatHub.onclose(error => console.log(error))
                chatHub.on("AcceptMessage", (message)=>{
                    debugger
                    setMessages([message, ...messages])
                })
            });
        }
    }, [chatHub]);

    return (
        <div className={cs.screenContainer}>
            <ChatHeader photoUrl={'https://cs5.pikabu.ru/post_img/2015/12/15/11/1450209491166030901.jpg'}
                        chatName={props.chat.ChatName} onCallClick={() => {
                props.onCallClick(chatId)
            }}/>
            <MessageContainer messages={messages} userLogin={props.user.login}/>
            <SendMessageForm sendMessage={(message)=>
               {
                   console.log(chatHub.state)
                   chatHub.send("SendMessage", message, props.user.login, chatId)
               }}/>
        </div>
    );
}

function ChatHeader(props) {
    return (
        <div className={cs.chatHeader}>
            <img className={cs.chatIcon} src={props.photoUrl} />
            <div className={cs.chatName}>{props.chatName}</div>
            <button type={'button'} className={cs.btn} onClick={props.onCallClick}>
                <img className={cs.btnIcon} src={'video_icon.png'}/>
            </button>
            <button type={'button'} className={cs.btn}>
                <img className={cs.btnIcon} src={'search_icon.png'} />
            </button>
            <button type={'button'} className={cs.btn}>
                <img className={cs.btnDotsIcon} src={'three_dots.png'} />
            </button>
        </div>
    );
}


export default ChatScreen;
