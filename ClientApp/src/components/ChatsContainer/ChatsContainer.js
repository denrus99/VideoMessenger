import React from 'react';
import cs from './ChatsContainer.module.css';

import Chat from '../Chat/Chat';


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
