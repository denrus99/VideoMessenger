import React from 'react';
import cs from './Message.module.css';


function Message({ message }) {
  return (
    <div className={cs.message}>
      <div className={cs.messageText}>
        {message}
      </div>

    </div>
  );
}


export default Message;
