import React from 'react';
import cs from './SendMessageForm.module.css';
import { Button } from 'reactstrap';

function SendMessageForm() {
  return (
    <form className={cs.sendMessageForm}>
      <input type="text" 
        className={cs.inputMessage}
        placeholder='Enter your message here...'  
      />
      <Button size='sm'>&#x02AA2;</Button>
    </form>
  );
}


export default SendMessageForm;