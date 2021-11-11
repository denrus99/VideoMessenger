import React from 'react';
import Chat from '../Chat/Chat';
import cs from './ChatsContainer.module.css';


function ChatsContainer({ chats }) {
  return (
    <div className={cs.chatsContainer}>
      {
        chats.map((chat, index) => {
          return <Chat key={index} chat={chat}/>
        })
      }
    </div>
  );
}


export default ChatsContainer;
