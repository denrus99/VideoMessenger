import React, {useState} from 'react';
import cs from './SendMessageForm.module.css';


function SendMessageForm(props) {
    const [message, setMessage] = useState("");
    return (
        <div className={cs.sendMessageForm}>
            <input type="text"
                   className={cs.inputMessage}
                   placeholder='Enter your message here...'
                   value={message}
                   onChange={(event)=>{
                       setMessage(event.target.value);
                   }}
            />
            <button type={'button'} className={cs.sendBtn} onClick={()=>{
                if(message){
                    props.sendMessage(message);
                    setMessage("");
                }
            }}>
                <img className={cs.sendBtnImg} src={'send_icon.png'}/>
            </button>
        </div>
    );
}


export default SendMessageForm;