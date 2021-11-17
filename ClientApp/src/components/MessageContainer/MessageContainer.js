import React from 'react';
import Message from '../Message/Message';
import cs from './MessageContainer.module.css';


function MessageContainer() {
  const messages = [
    'ssdfs dfsdssssssssssssssssdfsdfsd dffdsfdsf',
    'sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesh',
    'gfhdh dfhgdfh dfghdf ghd fghdfghdfghdf',
    'dasdasasdasdasdasd asdasdasdasd asdasdasd',
    'ssdfs dfsdssssssssssssssssdfsdfsd dffdsfdsf',
    'sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesh',
    'gfhdh dfhgdfh dfghdf ghd fghdfghdfghdf',
    'dasdasasdasdasdasd asdasdasdasd asdasdasd',
    'ssdfs dfsdssssssssssssssssdfsdfsd dffdsfdsf',
    'sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesh',
    'gfhdh dfhgdfh dfghdf ghd fghdfghdfghdf',
    'dasdasasdasdasdasd asdasdasdasd asdasdasd',
    'ssdfs dfsdssssssssssssssssdfsdfsd dffdsfdsf',
    'sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesh',
    'gfhdh dfhgdfh dfghdf ghd fghdfghdfghdf',
    'dasdasasdasdasdasd asdasdasdasd asdasdasd',
    'ssdfs dfsdssssssssssssssssdfsdfsd dffdsfdsf',
    'sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesh',
    'gfhdh dfhgdfh dfghdf ghd fghdfghdfghdf',
    'dasdasasdasdasdasd asdasdasdasd asdasdasd'
  ];

  return (
    <div className={cs.messageContainer}>
      {
        messages.map((m, i) => {
          return (
            <Message key={i} message={m}/>
          );
        })
      }
    </div>
  );
}


export default MessageContainer;
