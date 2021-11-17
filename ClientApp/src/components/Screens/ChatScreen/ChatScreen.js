import React from 'react';
import cs from './ChatScreen.module.css'
import { Button } from 'reactstrap';
import MessageContainer from '../../MessageContainer/MessageContainer';
import SendMessageForm from '../../Forms/SendMessageForm';

function ChatScreen() {
  return (
    <div className={cs.screenContainer}>

      <div className={cs.chatInfo}>
        <div className={cs.chatIcon} />
        <div className={cs.chatName}>Some chat</div>
        <Button className={cs.btn}>&#x02315;</Button>
        <Button className={cs.btn}>&hellip;</Button>
      </div>
      <MessageContainer />
      <SendMessageForm />
    </div>
  );
}


export default ChatScreen;
