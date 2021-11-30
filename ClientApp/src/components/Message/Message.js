import React from 'react';
import cs from './Message.module.css';


function Message(props) {
  return (
    <div className={(props.message.local) ? cs.localMessage : cs.message}>
      <div className={cs.messageText}>
        {props.message.text}
      </div>

    </div>
  );
}


export default Message;
