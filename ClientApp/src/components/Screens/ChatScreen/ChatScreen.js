import React from 'react';
import cs from './ChatScreen.module.css'
import {Button} from 'reactstrap';
import MessageContainer from '../../MessageContainer/MessageContainer';
import SendMessageForm from '../../Forms/SendMessageForm';

function ChatScreen(props) {
    const roomId = 'aaeb682b-f748-401c-b48a-7172d7b89858';
    return (
        <div className={cs.screenContainer}>
            <ChatHeader photoUrl={'https://cs5.pikabu.ru/post_img/2015/12/15/11/1450209491166030901.jpg'}
                        chatName={'Some chat'} onCallClick={()=>{props.onCallClick(roomId)}}/>
            <MessageContainer/>
            <SendMessageForm/>
        </div>
    );
}

function ChatHeader(props) {
    return (
        <div className={cs.chatHeader}>
            <img className={cs.chatIcon} src={props.photoUrl}/>
            <div className={cs.chatName}>{props.chatName}</div>
            <button type={'button'} className={cs.btn}  onClick={props.onCallClick}>
                <img className={cs.btnIcon} src={'video_icon.png'}/>
            </button>
            <button type={'button'} className={cs.btn}>
                <img className={cs.btnIcon} src={'search_icon.png'}/>
            </button>
            <button type={'button'} className={cs.btn}>
                <img className={cs.btnDotsIcon} src={'three_dots.png'}/>
            </button>
        </div>
    );
}


export default ChatScreen;
