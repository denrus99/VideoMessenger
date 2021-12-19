import React from 'react';
import cs from './SendMessageForm.module.css';


function SendMessageForm() {
    return (
        <div className={cs.sendMessageForm}>
            <input type="text"
                   className={cs.inputMessage}
                   placeholder='Enter your message here...'
            />
            <button type={'button'} className={cs.sendBtn}>
                <img className={cs.sendBtnImg} src={'send_icon.png'}/>
            </button>
        </div>
    );
}


export default SendMessageForm;