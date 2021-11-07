import React from 'react';
import Message from '../Message/Message';
import cs from './MessagesContainer.module.css';


function MessagesContainer({ messages }) {
  return (
    <div className={cs.messagesContainer}>
      {
        messages.map((message, index) => {
          return <Message key={index} message={message}/>
        })
      }
    </div>
  );
}


export default MessagesContainer;
