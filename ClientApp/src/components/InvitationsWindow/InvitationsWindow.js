import React, { useEffect, useState } from 'react';
import { getInvitations, acceptChat } from '../../utils/fetchs'
import cs from './InvitationsWindow.module.css';


function InvitationsWindow(props) {
    const [invitations, setInvitations] = useState([]);

    useEffect(() => {
        const fetchInvitations = async () => {
            const response = await getInvitations(props.login);
            if (response.status) {
                setInvitations(response.invitations);
            } else {
                alert('Не удалось загрузить инвайты.');
            }
        }
        fetchInvitations();
    }, [props.login]);

    return (
        <div className={cs.overlay} onClick={props.closeForm}>
            <div className={cs.invitationsWindow} onClick={(evt) => evt.stopPropagation()}>
                <div className={cs.title}>Приглашения</div>
                <div className={cs.invitationsContainer}>
                    {invitations.length !== 0
                        ? invitations.map((chat, index) =>
                            <Invitation
                                key={chat.ChatId}
                                recipientLogin={props.login}
                                chat={chat}
                                removeInvitation={() => setInvitations(invitations.filter((_, i) => index !== i))} 
                                addChat={props.addChat}/>)
                        : <div className={cs.empty}>{'Здесь пока пусто'}</div>
                    }
                </div>
                <div className={cs.btnCloseWrapper}>
                    <button className={cs.btnClose} onClick={props.closeForm}>Закрыть</button>
                </div>
            </div>
        </div>
    );
}

const Invitation = ({ recipientLogin, chat, removeInvitation, addChat }) => {
    const acceptInvitation = () => {
        acceptChat(recipientLogin, chat.ChatId);
        removeInvitation();
        addChat(chat);
    };

    return (
        <div className={cs.invitation} key={chat.ChatId}>
            <div className={cs.invitationName}>
                {`${chat.Sender.Login} приглашает в ${chat.ChatName}`}
            </div>
            <button className={cs.btnReject}>
                <img src={'cross.png'} />
            </button>
            <button className={cs.btnAccept} onClick={acceptInvitation}>
                <img src={'check.png'} />
            </button>
        </div>
    );
}

export default InvitationsWindow;
