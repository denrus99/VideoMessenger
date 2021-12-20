using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace VideoMessenger.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public string Data { get; set; }
        public DateTime CreationDate { get; set; }

        public bool IsReaded { get; set; }

        public Message()
        {
            
        }

        public Message(int id, int senderId, User sender, int chatId, Chat chat, string data)
        {
            Id = id;
            SenderId = senderId;
            Sender = sender;
            ChatId = chatId;
            Chat = chat;
            Data = data;
            CreationDate = DateTime.Now;
            IsReaded = false;
        }
    }
}
