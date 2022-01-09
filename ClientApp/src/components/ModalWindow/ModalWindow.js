import React from "react";
import cs from './ModalWindow.module.css';


function ModalWindow(props) {
    const title = props.title;

    return (
        <Overlay close={props.close}>
            <div className={cs.modalWindow} onClick={evt => evt.stopPropagation()}>
                <div className={cs.title}>{title}</div>
                <div className={cs.container}>
                    {props.children}
                </div>
                <div className={cs.btnCloseWrapper}>
                    <button className={cs.btnClose} onClick={props.close}>Закрыть</button>
                </div>
            </div>
        </Overlay>
    );
}

const Overlay = (props) => {
    return (
        <div className={cs.overlay} onClick={props.close}>
            {props.children}
        </div>
    );
};


export default ModalWindow;