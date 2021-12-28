using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoMessenger.Models;

namespace VideoMessenger.ViewModels
{
    public class ChatInfo
    {
        public int ChatId { get; set; }
        public string ChatName { get; set; }
        public MessagesInfo LastMessage { get; set; }

        public ChatInfo(Chat chat, Message lastMessage)
        {
            LastMessage = lastMessage is null ? null : new MessagesInfo(lastMessage);
            ChatId = chat.Id;
            ChatName = chat.ChatName;
        }
    }
}
