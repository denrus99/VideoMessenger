import React from 'react';
import Message from '../Message/Message';
import cs from './MessageContainer.module.css';


function MessageContainer() {
  const messages = [
    {id:1, text: 'ssdfs dfsdssssssssssssssssdfsdfsd dffdsfdsf', local: true},
    {id:2, text: 'sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesh', local: true},
    {id:3, text: 'gfhdh dfhgdfh dfghdf ghd fghdfghdfghdf', local: true},
    {id:4, text: 'dasdasasdasdasdasd asdasdasdasd asdasdasd', local: false},
    {id:5, text: 'ssdfs dfsdssssssssssssssssdfsdfsd dffdsfdsf', local: true},
    {id:6, text: 'sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesh', local: true},
    {id:7, text: 'gfhdh dfhgdfh dfghdf ghd fghdfghdfghdf', local: false},
    {id:8, text: 'dasdasasdasdasdasd asdasdasdasd asdasdasd', local: false},
    {id:9, text: 'ssdfs dfsdssssssssssssssssdfsdfsd dffdsfdsf', local: true},
    {id:10, text: 'sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesh', local: true},
    {id:11, text: 'gfhdh dfhgdfh dfghdf ghd fghdfghdfghdf', local: true},
    {id:12, text: 'dasdasasdasdasdasd asdasdasdasd asdasdasd', local: false},
    {id:13, text: 'ssdfs dfsdssssssssssssssssdfsdfsd dffdsfdsf', local: true},
    {id:14, text: 'sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesh', local: true},
    {id:15, text: 'gfhdh dfhgdfh dfghdf ghd fghdfghdfghdf', local: true},
    {id:16, text: 'dasdasasdasdasdasd asdasdasdasd asdasdasd', local: true},
    {id:17, text: 'ssdfs dfsdssssssssssssssssdfsdfsd dffdsfdsf', local: false},
    {id:18, text: 'sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesh', local: true},
    {id:19, text: 'gfhdh dfhgdfh dfghdf ghd fghdfghdfghdf', local: true},
    {id:20, text: 'dasdasasdasdasdasd asdasdasdasd asdasdasd', local: false},
    {id:21, text: 'ssdfs dfsdssssssssssssssssdfsdfsd dffdsfdsf', local: true},
    {id:22, text: 'sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesh', local: true},
    {id:23, text: 'gfhdh dfhgdfh dfghdf ghd fghdfghdfghdf', local: true},
    {id:24, text: 'dasdasasdasdasdasd asdasdasdasd asdasdasd', local: true},
    {id:25, text: 'ssdfs dfsdssssssssssssssssdfsdfsd dffdsfdsf', local: true},
    {id:26, text: 'sheeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeesh', local: true},
    {id:27, text: 'gfhdh dfhgdfh dfghdf ghd fghdfghdfghdf', local: false},
    {id:28, text: 'dasdasasdasdasdasd asdasdasdasd asdasdasd', local: false}
  ];
  messages.reverse();

  return (
    <div className={cs.messageContainer}>
      {
        messages.map((m, i) => {
          return (
            <Message key={m.id} message={m}/>
          );
        })
      }
    </div>
  );
}


export default MessageContainer;
