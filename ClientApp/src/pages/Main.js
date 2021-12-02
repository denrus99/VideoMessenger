import React, { createContext, useContext, useReducer } from 'react';
import Sidebar from '../components/Sidebar/Sidebar';

import EmptyScreen from '../components/Screens/EmptyScreens/EmptyScreen'
import ChatScreen from '../components/Screens/ChatScreen/ChatScreen';
import VideoScreen from '../components/Screens/VideoScreen/VideoScreen';


function Main(props) {
  const chats = [
    {
      user: {
        name: 'Petya',
        avatar: 'olive',
      },
      text: 'Zdarova',
    },
    {
      user: {
        name: 'Vanya',
        avatar: 'midnightblue',
      },
      text: 'Sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesh',
    },
    {
      user: {
        name: 'Alexey',
        avatar: 'seagreen',
      },
      text: 'Chupapi Munyanya',
    },
    {
      user: {
        name: 'Vanya',
        avatar: 'midnightblue',
      },
      text: 'Maksim lox',
    },
    {
      user: {
        name: 'Vanya',
        avatar: 'midnightblue',
      },
      text: 'Maksim lox',
    },
    {
      user: {
        name: 'Vanya',
        avatar: 'midnightblue',
      },
      text: 'Maksim lox',
    },
    {
      user: {
        name: 'Vanya',
        avatar: 'midnightblue',
      },
      text: 'Maksim lox',
    },
    {
      user: {
        name: 'Vanya',
        avatar: 'midnightblue',
      },
      text: 'Maksim lox',
    },
    {
      user: {
        name: 'Vanya',
        avatar: 'midnightblue',
      },
      text: 'Maksim lox',
    },
    {
      user: {
        name: 'Vanya',
        avatar: 'midnightblue',
      },
      text: 'Maksim lox',
    },
    {
      user: {
        name: 'Vanya',
        avatar: 'midnightblue',
      },
      text: 'Maksim lox',
    },
    {
      user: {
        name: 'Vanya',
        avatar: 'midnightblue',
      },
      text: 'Maksim lox',
    },
    {
      user: {
        name: 'Vanya',
        avatar: 'midnightblue',
      },
      text: 'Maksim lox',
    },
        {
      user: {
        name: 'Vanya',
        avatar: 'midnightblue',
      },
      text: 'Maksim lox',
    },
  ];

  return (
    <>
      <Sidebar chats={chats} />
      {props.children}
      {/* <VideoScreen /> */}
      {/* <ChatScreen /> */}
    </>
  );
}

export default Main;
