import React from 'react';
import cs from './Sidebar.module.css';

import ChatsContainer from '../ChatsContainer/ChatsContainer';


function Sidebar({ chats }) {
  return (
    <div className={cs.sidebar}>
      <SidebarHeader />
      <ChatsContainer chats={chats} />
    </div>
  );
}

const SidebarHeader = () => {
  return (
    <div className={cs.sidebarHeader}>
      <button className={cs.btnBurger}>&#x02261;</button>
      <input type="text" className={cs.searchInput} placeholder='&#x02315; Поиск' />
    </div>
  );
}


export default Sidebar;
