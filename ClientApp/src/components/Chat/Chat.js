import React from 'react';
import cs from './Chat.module.css';
import {getUserInfo} from "../../utils/fetchs";


function Chat({chat, onChatClick}) {
    return (
        <div className={cs.chat} onClick={() => onChatClick(chat)}>
            {/*<UserIcon color={chat.user.avatar} />*/}
            <ChatContent chatName={chat.ChatName} fromUser={chat.LastMessage.Sender.Login}
                         textMessage={chat.LastMessage.Data}/>
        </div>
    );
}

const UserIcon = ({color}) => {
    return (
        <div className={cs.userIcon} style={{backgroundColor: color}}/>
    );
};

const ChatContent = (props) => {
    return (
        <div className={cs.chatContent}>
            <div className={cs.chatName}>{props.chatName}</div>
            {props.textMessage == "В этом чате нет сообщений." && <div className={cs.lastMessage}>
                <div className={cs.lastMessageText}>{props.textMessage}</div>
            </div>
            }
            {props.textMessage != "В этом чате нет сообщений." && <div className={cs.lastMessage}>
                <div className={cs.lastMessageSender}>{props.fromUser + ":"}</div>
                <div className={cs.lastMessageText}>{props.textMessage}</div>
            </div>
            }

        </div>
    );
};

export default Chat;
