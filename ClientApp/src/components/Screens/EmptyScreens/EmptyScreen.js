import React from 'react';
import cs from './EmptyScreen.module.css';


function EmptyScreen() {
  return (
    <div className={cs.screenContainer}>
      <div className={cs.choose}>Choose chat</div>
    </div>
  );
}


export default EmptyScreen;