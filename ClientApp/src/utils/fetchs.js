const loginUser = async function (login, password) {
    let model = {
        emailAddress: login,
        password
    };
    let response = await fetch("/auth",{
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(model)
    });
    let user = await response.json();
    debugger;
    return {
        status: response.ok,
        user
    }
};

const registerUser = async function(login, emailAddress, phoneNumber, password){
    let model = {
        login,
        emailAddress,
        phoneNumber,
        password
    };
    let response = await fetch("/register",{
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(model)
    });
    let user = await response.json();
    debugger;
    return {
        status: response.ok,
        user
    }
};

const getMessages = async function(chatId){
    let response = await fetch(`/chats/${chatId}/messages`,{
        method: 'GET'
    });
    let messages = await response.json();
    return {
        status: response.ok,
        messages
    }
};

const createChat = async function(chatName, senderLogin, recipientLogins){
    let body = {
        chatName,
        senderLogin,
        recipientLogins
    };
    debugger
    let response = await fetch("/chats",{
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(body)
    });
    return {
        status: response.ok
    }
};

const addFriend = async function(senderLogin, recipientLogin){
    let body = {
        senderLogin,
        recipientLogin
    };
    let response = await fetch("/friend/invite",{
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(body)
    });
    return {
        status: response.ok
    }
};

const acceptFriend = async function(user, friend){
    let body = {
        user,
        friend
    };
    let response = await fetch("/friend/accept",{
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(body)
    });
    return {
        status: response.ok
    }
};

const removeFriend = async function(user, friend){
    let body = {
        user,
        friend
    };
    let response = await fetch("/friend/delete",{
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(body)
    });
    return {
        status: response.ok
    }
};

const getFriends = async function(login){
    let response = await fetch(`/friend/${login}`,{
        method: 'GET'
    });
    let friends = await response.json();
    return {
        status: response.ok,
        friends
    }
};

const getUserInfo = async function(login){
    let response = await fetch(`/account/${login}`,{
        method: 'GET'
    });
    let info = await response.json();
    return {
        status: response.ok,
        info
    }
};

const getChats = async function(login){
    let response = await fetch(`/account/${login}/chats`,{
        method: 'GET'
    });
    let chats = await response.json();
    return {
        status: response.ok,
        chats
    }
};

export {getChats, 
    getUserInfo, 
    getFriends, 
    removeFriend, 
    acceptFriend, 
    addFriend, 
    createChat, 
    getMessages,
    registerUser, 
    loginUser}