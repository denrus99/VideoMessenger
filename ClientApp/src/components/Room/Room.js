import React, { useEffect } from 'react';
import { useParams } from "react-router";
import useNewWebRTC from '../../hooks/useNewWebRtc.js'
import cs from "./Room.module.css";

const Video = (props) => {
    const localVideo = React.createRef();

    useEffect(() => {
        if (localVideo.current)
            localVideo.current.srcObject = props.stream;
    }, [props.stream, localVideo]);

    return (
        <video ref={localVideo} autoPlay muted={props.isMuted} style={{
            width: 'auto',
            height: props.height,
            marginTop: '1%',
            borderRadius: '5%',
            boxShadow: '0 2px 4px 4px'
        }} />
    );
};

function CallHeader(props) {
    return (
        <div className={cs.callHeader}>
            <img className={cs.callIcon} src={props.photoUrl} />
            <div className={cs.callName}>{props.callName}</div>
            <button type={'button'} className={cs.btn}>
                <img className={cs.btnDotsIcon} src={'/three_dots.png'} />
            </button>
        </div>
    );
}

export default function Room() {
    const { id: roomId } = useParams();
    const [localStream, remoteStreams] = useNewWebRTC(roomId);
    const testImgs = [
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg",
        "https://hot-game.info/uploads/media/slide_game/0001/44/thumb_43487_slide_game_full.jpeg"
    ];

    return (
        <div className={cs.screenContainer}>
            <CallHeader callName={'Some call'}
                photoUrl={'https://cs5.pikabu.ru/post_img/2015/12/15/11/1450209491166030901.jpg'} />
            <div className={cs.videoContainer}>
                {/*{testImgs.map((url) => <img src={url}*/}
                {/*                            style={{*/}
                {/*                                width: 'auto',*/}
                {/*                                height: getHeight(testImgs.length),*/}
                {/*                                marginTop: '1%',*/}
                {/*                                borderRadius: '5%',*/}
                {/*                                boxShadow: '0 2px 4px 4px'*/}
                {/*                            }}/>)}*/}
                <Video stream={localStream} isMuted={true} height={getHeight(remoteStreams.length)} />
                {remoteStreams.map((remoteStream) => <Video stream={remoteStream} isMuted={false}
                    height={getHeight(remoteStreams.length)} />)}
            </div>
            <div className={cs.callPanel}>
                <button type={'button'} className={cs.panelBtn}>
                    <img src={'/camera_icon.png'} className={cs.panelBtnIcon} />
                </button>
                <button type={'button'} className={cs.panelBtn}>
                    <img src={'/add_icon.png'} className={cs.panelBtnIcon} />
                </button>
                <button type={'button'} className={cs.panelBtn}>
                    <img src={'/mic_icon.png'} className={cs.panelBtnIcon} />
                </button>
                <button type={'button'} className={cs.declineBtn}>
                    <img src={'/telephone_icon.png'} className={cs.panelBtnIcon} />
                </button>
            </div>
        </div>
    );
}

function getHeight(elementsNumber) {
    return (elementsNumber <= 9) ? '30%' : (elementsNumber <= 20) ? '20%' : '10%';
}