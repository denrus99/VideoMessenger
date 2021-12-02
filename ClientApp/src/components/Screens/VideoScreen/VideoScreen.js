import React from 'react';
import cs from './VideoScreen.module.css';
import screenHeader_cs from '../ScreenHeader/ScreenHeader.module.css';

import ScreenHeader from '../ScreenHeader/ScreenHeader'
import VideosContainer from '../../VideosContainer/VideosContainer';


function VideoScreen() {
  return (
    <div className={cs.screenContainer}>
      <ScreenHeader>
        <button className={screenHeader_cs.btn}>&#8942;</button>
      </ScreenHeader>
      <VideosContainer />

      { /* */ }
      
    </div>
  );
}


export default VideoScreen;
