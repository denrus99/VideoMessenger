import React from 'react';
import Chat from '../Chat/Chat';
import cs from './ChatsContainer.module.css';


function ChatsContainer(props) {
  return (
    <div className={cs.chatsContainer}>
      {
        props.chats.map((chat, index) => {
          return <Chat key={index} chat={chat} onChatClick={()=>{props.onChatClick()}}/>
        })
      }
    </div>
  );
}


export default ChatsContainer;
