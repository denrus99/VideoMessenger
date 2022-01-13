import React from 'react';
import cs from './Message.module.css';
import moment from 'moment';
import 'moment/locale/ru';


function Message(props) {
    if (props.message.Data){
        return (
            <div className={(props.message.Sender.Login == props.userLogin) ? cs.localMessage : cs.message}>
                <div className={cs.container}>
                    <div className= {cs.userLogin}>
                        {(props.message.Sender.Login == props.userLogin) ? "Вы:" : props.message.Sender.Login + ":"}
                    </div>
                    <div className={cs.messageText}>
                        {props.message.Data}
                    </div>
                    <div className={cs.messageDate}>
                        {getDateInRightFormat(props.message.CreationDate)}
                    </div>
                </div>                
            </div>
        );
    }
    else {
        return (
            <div className={(props.message.sender.login == props.userLogin) ? cs.localMessage : cs.message}>
                <div className= {cs.userLogin}>
                    {(props.message.sender.login == props.userLogin) ? "Вы:" : props.message.sender.login + ":"}
                    <div className={cs.messageText}>
                        {props.message.data}
                    </div>
                    <div className={cs.messageDate}>
                        {getDateInRightFormat(props.message.creationDate)}
                    </div>
                </div>
            </div>
        );
    }

}

function getDateInRightFormat(dateString){
    moment.locale('ru');
    let date = moment(new Date(Date.parse(dateString)));
    return date.calendar();
}


export default Message;
