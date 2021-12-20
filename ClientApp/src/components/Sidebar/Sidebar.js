import React, { useState } from 'react';
import cs from './Sidebar.module.css';
import ChatsContainer from '../ChatsContainer/ChatsContainer';

function SidebarMenu(props) {
    if (props.show) {
        return (
            <div className={cs.sidebarMenu}>
                <img className={cs.userAvatar} src={'/avatar_test.png'} />
                <div className={cs.userEmail}>
                    <img src={'email_icon.png'} className={cs.userEmailIcon} />
                    <div>
                        <div style={{ fontWeight: 'bold' }}>{props.userEmail}</div>
                        <div style={{ fontSize: '12px' }}>Почта</div>
                    </div>
                </div>
                <div className={cs.userLogin}>
                    <img src={'login_icon.png'} className={cs.userLoginIcon} />
                    <div>
                        <div style={{ fontWeight: 'bold' }}>{props.userLogin}</div>
                        <div style={{ fontSize: '12px' }}>Имя пользователя (логин)</div>
                    </div>
                </div>
                <button type={'button'} className={cs.sidebarMenuBtn} onClick={props.openCreateChatForm}>
                    Создать чат
                </button>
                <button type={'button'} className={cs.sidebarMenuBtn}>
                    Начать видеозвонок
                </button>
                <button type={'button'} className={cs.sidebarMenuBtn} onClick={props.openInvitationsWindow}>
                    Приглашения
                </button>
                <button type={'button'} className={cs.sidebarMenuBtn}>
                    Сменить пароль
                </button>
                <button type={'button'} className={cs.sidebarMenuBtn}>
                    Выйти
                </button>
            </div>
        );
    }
    return null;
}

function Sidebar(props) {
    const [showMenu, setShow] = useState(false);
    const userLogin = 'WJules';
    const userEmail = 'Jules.Winston@gmail.com';

    return (
        <div className={cs.sidebar}>
            <SidebarHeader onMenuClick={() => { setShow(!showMenu) }} />
            <SidebarMenu 
                show={showMenu} 
                userLogin={userLogin} 
                userEmail={userEmail} 
                openCreateChatForm={props.openCreateChatForm} 
                openInvitationsWindow={props.openInvitationsWindow}
            />
            <div className={cs.sidebarContainer}>
                <ChatsContainer chats={props.chats} onChatClick={props.onChatClick}/>
            </div>
        </div>
    );
}

const SidebarHeader = (props) => {
    return (
        <div className={cs.sidebarHeader}>
            <img className={cs.menuIcon} src={'/menu_icon.png'} onClick={props.onMenuClick} />
            <div className={cs.searchPanel}>
                <button type={'button'} className={cs.searchBtn}>
                    <img className={cs.searchIcon} src={'/search_icon.png'} />
                </button>
                <input className={cs.searchInput} placeholder={'Поиск...'} />
            </div>
        </div>
    );
}

export default Sidebar;
