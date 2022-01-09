import React, { createContext, useContext, useReducer, useState, useEffect } from 'react';
import { Route, Switch } from "react-router-dom";
import { useHistory } from "react-router";
import { getChats, registerUser, loginUser, createChat } from "../../utils/fetchs"
import Sidebar from '../Sidebar/Sidebar';
import ChatScreen from '../Screens/ChatScreen/ChatScreen';
import Home from "../Screens/Home/Home";
import Signin from "../Signin/Signin";
import Room from "../Room/Room";
import cs from "./Main.module.css"
import InvitationsWindow from '../InvitationsWindow/InvitationsWindow';
import CreateChatWindow from '../CreateChatWindow/CreateChatWindow';
import {HubConnectionBuilder} from "@microsoft/signalr";


// function CreateChat(props) {
//     let requestData = {
//         chatName: undefined,
//         senderLogin: props.login,
//         recipientLogins: undefined
//     };
//     const getRecipentLogins = (event) => {
//         let arr = event.target.value.split('\n');
//         if (arr.length > 0) {
//             requestData.recipientLogins = [];
//             arr.forEach((item) => {
//                 requestData.recipientLogins.push(item);
//             });
//         }
//     };
//     return (
//         <div className={cs.formBackground}>
//             <div className={cs.createForm}>
//                 <div className={cs.createFormInput}>
//                     <label htmlFor={'chatName'}>Название чата</label>
//                     <input id={'chatName'} className={cs.createFormInput} onChange={(event) => {
//                         requestData.chatName = event.target.value;
//                     }} />
//                 </div>
//                 <div className={cs.createFormInput}>
//                     <label htmlFor={'recipentLogins'}>Участники чата</label>
//                     <textarea id={'recipentLogins'} className={cs.createFormInput} onChange={(event) => {
//                         getRecipentLogins(event);
//                     }} />
//                 </div>
//                 <button type={'button'} onClick={async function () {
//                     if (requestData.chatName && requestData.senderLogin && requestData.recipientLogins) {
//                         let result = await createChat(requestData.chatName, requestData.senderLogin, requestData.recipientLogins);
//                         if (result.status)
//                             getChats(requestData.senderLogin).then((result)=>{
//                                 props.closeForm(result.chats);
//                             });
//                         else
//                             alert("Не удалось создать чат.")
//                     }
//                 }}>
//                     Создать чат
//                 </button>
//             </div>
//         </div>
//     )
// }

function Main() {
    const history = useHistory();
    const [user, setUser] = useState(undefined);
    const [chats, setChats] = useState([]);
    const [isTest, setTest] = useState(false);
    const [isAuth, setAuth] = useState(false);
    const [showCreateChat, setShowCreateChat] = useState(false);
    const [showChatScreen, setShowChatScreen] = useState(false);
    const [currentChat, setCurrentChat] = useState(undefined);
    const [showInvitations, setShowInvitations] = useState(false);

    useEffect(async function(){
        if (user) {
            let response = await getChats(user.login);
            if (response.status) {
                setChats(response.chats)
            } else {
                alert("Не удалось загрузить список чатов.")
            }
        }
    }, [user]);
    useEffect(() => {
        if (user !== undefined) {
            setAuth(true);
        }
    }, [user]);
    useEffect(()=>{
        if (currentChat){
            setShowChatScreen(true);
        }
    }, [currentChat]);

    const authenticateUser = async function (newUser, userData) {
        let response;
        if (newUser) {
            response = await registerUser(userData.login, userData.emailAddress,
                userData.phoneNumber, userData.password);
        } else {
            response = await loginUser(userData.emailAddress, userData.password);
        }
        if (response.status) {
            setUser(response.user);
        } else {
            alert("Не удалось аутентифицировать пользователя. Ошибка: " + user)
        }
    };

    return (
        <div className={cs.main}>
            {!isAuth && <Signin authenticateUser={authenticateUser}/>}
            {isAuth && showCreateChat && <CreateChatWindow login={user.login}
                                                     closeForm={(newChats) => {
                                                         setShowCreateChat(false)
                                                         setChats(newChats)
                                                     }}/>}
            {isAuth && showInvitations && <InvitationsWindow 
                login={user.login} 
                closeForm={() => setShowInvitations(false)} 
                addChat={(chat) => setChats([...chats, chat])} />
            }
            {isAuth && <Sidebar
                user={user}
                chats={chats}
                openCreateChatForm={() => {
                    setShowCreateChat(true)
                }}
                onChatClick={(chat) => {
                    setCurrentChat(chat);
                    history.push(`/chat`);
                }}
                openInvitationsWindow={() => setShowInvitations(true)} />
            }
            {isAuth && showChatScreen && <ChatScreen
                onCallClick={(roomId) => {
                    setShowChatScreen(false);
                    setCurrentChat(undefined);
                    history.push(`/room/${roomId}`);
                }}
                user={user}
                chat={currentChat}
            />
            }
            {isAuth && <Rouiting
                currentChat={currentChat}
                onCallDeny={() => {
                    history.push('/')
                }}
                onCallClick={(roomId) => {
                    setShowChatScreen(false);
                    history.push(`/room/${roomId}`);
            }}/>}
        </div>
    );
}


const Rouiting = (props) => {
    return (
        <Switch>
            <Route exact path='/' component={Home} />
            <Route exact path='/room/:id'>
                <Room onCallDeny={props.onCallDeny}/>
            </Route>
        </Switch>
)
}

export default Main;
