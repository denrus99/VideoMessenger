import React from 'react';
import cs from './SendMessageForm.module.css';


function SendMessageForm() {
  return (
    <form className={cs.sendMessageForm}>
      <input type="text" 
        className={cs.inputMessage}
        placeholder='Enter your message here...'  
      />
      <button className={cs.btnSendMessage}>&#8657;</button>
    </form>
  );
}


export default SendMessageForm;
