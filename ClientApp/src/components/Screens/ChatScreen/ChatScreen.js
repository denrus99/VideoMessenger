import {React, useEffect, useState} from 'react';
import cs from './ChatScreen.module.css'
import MessageContainer from '../../MessageContainer/MessageContainer';
import SendMessageForm from '../../Forms/SendMessageForm';
import {HubConnectionBuilder} from "@microsoft/signalr";
import {getMessages} from "../../../utils/fetchs";
import {useClientMethod, useHubMethod} from "react-use-signalr";

function ChatScreen(props) {
    const chatId = props.chat.ChatId;
    const [chatHub, setChatHub] = useState();
    const sendMessage = useHubMethod(chatHub, "SendMessage");
    const joinChat = useHubMethod(chatHub, "JoinChat");
    const [messages, setMessages] = useState([]);
    useClientMethod(chatHub, "AcceptMessage", (message) => {
        setMessages([message, ...messages])
    });

    useEffect(() => {
        const fetchMessages = async () => {
            try {
                const response = await getMessages(chatId);
                if (response.status) {
                    setMessages(response.messages);
                }
            } catch (e) {
                console.log(e);
            }
        };
        fetchMessages().then(() => {
            setChatHub(new HubConnectionBuilder()
                .withUrl("/hubs/chat")
                .withAutomaticReconnect()
                .build());
        });
        return () => {
            if (chatHub !== undefined && chatHub?.state !== 'Disconnected') {
                chatHub.stop().then(() => {
                    setChatHub(undefined)
                })
            }
        }
    }, [chatId]);

    useEffect(() => {
        if (chatHub && chatHub.state === 'Disconnected') {
            chatHub.start().then(()=>
                joinChat.invoke(chatId, props.user.login));
        }
    }, [chatHub]);

    return (
        <div className={cs.screenContainer}>
            <ChatHeader photoUrl={'https://cs5.pikabu.ru/post_img/2015/12/15/11/1450209491166030901.jpg'}
                        chatName={props.chat.ChatName} onCallClick={() => {
                props.onCallClick(chatId)
            }}/>
            <MessageContainer messages={messages} userLogin={props.user.login}/>
            <SendMessageForm sendMessage={(message) => {
                sendMessage.invoke(message, props.user.login, chatId);
            }}/>
        </div>
    );
}

function ChatHeader(props) {
    return (
        <div className={cs.chatHeader}>
            <img className={cs.chatIcon} src={props.photoUrl}/>
            <div className={cs.chatName}>{props.chatName}</div>
            <button type={'button'} className={cs.btn} onClick={props.onCallClick}>
                <img className={cs.btnIcon} src={'video_icon.png'}/>
            </button>
            <button type={'button'} className={cs.btn}>
                <img className={cs.btnIcon} src={'search_icon.png'}/>
            </button>
            <button type={'button'} className={cs.btn}>
                <img className={cs.btnDotsIcon} src={'three_dots.png'}/>
            </button>
        </div>
    );
}


export default ChatScreen;
