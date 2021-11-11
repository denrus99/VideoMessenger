import React from 'react';
import cs from './Sidebar.module.css';
import ChatsContainer from '../ChatsContainer/ChatsContainer';


function Sidebar({ chats }) {
  return (
    <div className={cs.sidebar}>
      <UserProfile />
      <div className={cs.sidebarContainer}>
        <ChatsContainer chats={chats} />
        <Tools />
      </div>
    </div>
  );
}

const UserProfile = () => {
  return (
    <div className={cs.userProfile}>
      <div className={cs.userAvatar} />
      <div className={cs.userLogin}>User Login</div>
    </div>
  );
}

const Tools = () => {
  return (
    <div className={cs.tools}>
      {
        [0, 1, 2, 3, 4].map(index => {
          return (
            <div key={index} className={cs.tool}></div>
          );
        })
      }
    </div>
  );
}

export default Sidebar;
