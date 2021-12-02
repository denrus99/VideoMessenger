import React from 'react';
import cs from './ChatScreen.module.css'
import screenHeader_cs from '../ScreenHeader/ScreenHeader.module.css'

import MessageContainer from '../../MessageContainer/MessageContainer';
import SendMessageForm from '../../Forms/SendMessageForm';
import ChatScreenHeader from '../ScreenHeader/ScreenHeader';


function ChatScreen() {
  return (
    <div className={cs.screenContainer}>
      <ChatScreenHeader>
        <button className={screenHeader_cs.btn}>&#x0260E;</button>
        <button className={screenHeader_cs.btn}>&#x02315;</button>
        <button className={screenHeader_cs.btn}>&hellip;</button>
      </ChatScreenHeader>
      <MessageContainer />
      <SendMessageForm />
    </div>
  );
}


export default ChatScreen;
