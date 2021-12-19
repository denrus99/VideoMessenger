import React from 'react';
import cs from './Chat.module.css';


function Chat({ chat, onChatClick }) {
  return (
    <div className={cs.chat} onClick={() => onChatClick()}>
      {/*<UserIcon color={chat.user.avatar} />*/}
      <ChatContent fromUser={chat.lastMessage.senderId} textMessage={chat.lastMessage.data} />
    </div>
  );
}

const UserIcon = ({ color }) => {
  return (
    <div className={cs.userIcon} style={{ backgroundColor: color }} />
  );
};

const ChatContent = ({ fromUser, textMessage }) => {
  return (
    <div className={cs.chatContent}>
      <div className={cs.chatName}>{fromUser}</div>
      <div className={cs.textMessage}>{textMessage}</div>
    </div>
  );
};

export default Chat;
