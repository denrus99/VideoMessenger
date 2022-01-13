import React from 'react';
import Message from '../Message/Message';
import cs from './MessageContainer.module.css';


function MessageContainer(props) {
  let messages = props.messages;
  messages.sort(function(a,b) {
    return new Date(Date.parse(b.CreationDate)).getTime() - new Date(Date.parse(a.CreationDate)).getTime();
  });

  return (
    <div className={cs.messageContainer}>
      {
        messages.map((m, i) => {
          return (
            <Message key={m.Id} message={m} userLogin={props.userLogin}/>
          );
        })
      }
    </div>
  );
}


export default MessageContainer;
