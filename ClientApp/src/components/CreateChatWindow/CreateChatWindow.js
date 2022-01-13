import React, { useState } from 'react';
import cs from './CreateChatWindow.module.css';
import ModalWindow from '../ModalWindow/ModalWindow';
import {createChat, getChats} from '../../utils/fetchs';


function CreateChatWindow(props) {
    const userLogin = props.login;
    const [chatName, setChatName] = useState('');
    const [recipientValue, setRecipientValue] = useState('');
    const [recipients, setRecipients] = useState([])

    const onCreateChat = async () => {
        if (recipients.length === 0) {
            alert('Добавьте хотя бы одного участника.');
        } else if (!chatName) {
            alert('Введите название чата.');
        } else {
            const response = await createChat(chatName, userLogin, recipients);
            if (response.status) {
                getChats(userLogin).then((result)=>{
                    props.closeForm(result.chats);
                });
            } else {
                alert('Не удалось создать чат.');
            }
        }
    }

    const addRecipient = () => {
        // Нужна проверка, есть ли пользователь в базе
        if (recipientValue !== '' && !recipients.includes(recipientValue)) {
            setRecipients([...recipients, recipientValue]);
            setRecipientValue('');
        }
    };

    return (
        <ModalWindow close={props.closeForm} showCloseBtn={false} title={'Создание чата'}>
            <div className={cs.inputContent}>
                <label htmlFor={'chatName'}>Название чата</label>
                <div className={cs.inputWrapper}>
                    <input id={'chatName'} type="text"
                        value={chatName}
                        onChange={evt => setChatName(evt.target.value)} />
                </div>
            </div>
            <div className={cs.inputContent}>
                <label htmlFor={'recipientLogin'}>Участники</label>
                <div className={cs.inputWrapper}>
                    <input id={'recipientLogin'} type="text"
                        value={recipientValue}
                        onChange={evt => setRecipientValue(evt.target.value)}
                        onKeyUp={evt => evt.key === 'Enter' && addRecipient()} />
                </div>
                <button className={cs.btnAddRecipient} onClick={addRecipient}>
                    <img src="add_user.png" className={cs.btnIcon} />
                </button>
            </div>
            <div className={cs.recipientsContainer}>
                {
                    recipients.map((login, index) =>
                        <Recipient
                            key={login}
                            login={login}
                            remove={() => setRecipients(recipients.filter((_, i) => index !== i))} />)
                }
            </div>
            <button className={cs.btnCreateChat} type={'button'} onClick={onCreateChat}>
                Создать
            </button>
        </ModalWindow>
    );
}

const Recipient = ({ login, remove }) => {
    const [showRemove, setShowRemove] = useState(false);

    return (
        <div className={cs.recipient} onMouseOver={() => setShowRemove(true)} onMouseOut={() => setShowRemove(false)}>
            <div className={cs.recipientLogin}>{login}</div>
            <button
                className={cs.btnRemoveRecipient}
                style={showRemove ? { display: 'block' } : { display: 'none' }}
                onClick={remove}
            >
                <img src={'close.png'} className={cs.removeIcon} />
            </button>
        </div>
    );
}


export default CreateChatWindow;