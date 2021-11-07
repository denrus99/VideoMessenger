import React from 'react';
import MessagesContainer from '../components/MessagesContainer/MessagesContainer';
import cs from './Main.module.css';
import { Container } from 'reactstrap'


function Main() {
  const messages = [
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
      text: 'Maksim lox',
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
      <div className={cs.sidebar}>
        <div className={cs.userProfile}>
          <div className={cs.userAvatar} />
          <div className={cs.userLogin}>User Login</div>
        </div>
        <div className={cs.sidebarContainer}>
          <MessagesContainer messages={messages} />
          <div className={cs.tools}>
            {
              [0, 1, 2, 3, 4].map(index => {
                return (
                  <div key={index} className={cs.tool}></div>
                );
              })
            }
          </div>
        </div>
      </div>

      <div className={cs.base}>

      </div>
    </>
  );
}

export default Main;
