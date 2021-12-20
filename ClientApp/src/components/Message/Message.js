import React from 'react';
import cs from './Message.module.css';


function Message(props) {
    if (props.message.Data){
        return (
            <div className={(props.message.Sender.Login == props.userLogin) ? cs.localMessage : cs.message}>
                <div className={cs.messageText}>
                    {props.message.Data}
                </div>
            </div>
        );
    }
    else {
        return (
            <div className={(props.message.sender.login == props.userLogin) ? cs.localMessage : cs.message}>
                <div className={cs.messageText}>
                    {props.message.data}
                </div>
            </div>
        );
    }

}


export default Message;
