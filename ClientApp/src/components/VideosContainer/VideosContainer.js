import React from 'react';
import cs from './VideosContainer.module.css';


function VideosContainer() {
  return (
    <div className={cs.videosContainer}>
      <video poster="https://c.tenor.com/ySNBqbnZ5OYAAAAd/bidlo-cyka-blyat.gif" className={cs.video} />
      <video poster="https://c.tenor.com/a9E-VKhwK9kAAAAd/chips.gif" className={cs.video} />
      <video poster="https://c.tenor.com/wXSdSO_ilucAAAAd/papich-%D0%BF%D0%B0%D0%BF%D0%B8%D1%87.gif" className={cs.video}></video>
    </div>
  );
}


export default VideosContainer;