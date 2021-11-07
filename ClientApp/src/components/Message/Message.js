import React from 'react';
import cs from './Message.module.css';


function Message({ message }) {
  return (
    <div className={cs.message}>
      <div className={cs.userIcon} style={{backgroundColor: message.user.avatar}}/>
      <div className={cs.messageContent}>
        <h6>{message.user.name}</h6>
        <div>{message.text}</div>
      </div>
    </div>
  );
}

export default Message;
