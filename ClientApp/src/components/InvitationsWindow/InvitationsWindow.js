import React, { useEffect, useState } from 'react';
import { getInvitations, acceptChat } from '../../utils/fetchs'
import cs from './InvitationsWindow.module.css';


function InvitationsWindow(props) {
    const [invitations, setInvitations] = useState([]);

    const fetchInvitations = async () => {
        const response = await getInvitations();
        if (response.status) {
            setInvitations(response.invitations);
        } else {
            alert('Не удалось загрузить инвайты.');
        }
    }

    useEffect(() => fetchInvitations(), []);

    return (
        <div className={cs.overlay} onClick={props.closeForm}>
            <div className={cs.invitationsWindow} onClick={(evt) => evt.stopPropagation()}>
                <div className={cs.title}>Приглашения</div>
                <div className={cs.invitationsContainer}>
                    {invitations.length !== 0
                        ? invitations.map((chat, _) => <Invitation chat={chat} />)
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

const Invitation = ({ chat }) => {
    return (
        <div className={cs.invitation} key={chat.id}>
            <div className={cs.invitationName}>
                {'chatId: ' + chat.id}
            </div>
            <button className={cs.btnReject}>
                <img src={'cross.png'} />
            </button>
            <button className={cs.btnAccept} onClick={acceptChat}>
                <img src={'check.png'} />
            </button>
        </div>
    );
}

export default InvitationsWindow;
