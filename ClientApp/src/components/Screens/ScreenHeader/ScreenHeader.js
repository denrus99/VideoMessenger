import React from 'react';
import cs from './ScreenHeader.module.css';


function ScreenHeader(props) {
  return (
    <div className={cs.chatScreenHeader}>
      <div className={cs.chatIcon} />
      <div className={cs.chatName}>Some chat</div>
      <div className={cs.tools}>
        {props.children}
      </div>
    </div>
  );
};


export default ScreenHeader;
