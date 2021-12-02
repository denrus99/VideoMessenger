import React from 'react';
import cs from './Chat.module.css';


function Chat({ chat }) {
  return (
    <div className={cs.chat}>
      <UserIcon color={chat.user.avatar} />
      <ChatContent fromUser={chat.user.name} textMessage={chat.text} />
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
      <div className={cs.chatHeader}>
        <div className={cs.chatName}>{fromUser}</div>
        <div className={cs.chatTime}>00:00</div>
      </div>
      <div className={cs.textMessage}>{textMessage}</div>
    </div>
  );
};

export default Chat;
