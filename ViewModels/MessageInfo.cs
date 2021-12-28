using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoMessenger.Models;

namespace VideoMessenger.ViewModels
{
    public class MessagesInfo
    {
        public DateTime CreationDate { get; set; }
        public string Data { get; set; }
        public bool isReaded { get; set; }
        public UserInfo Sender { get; set; }

        public MessagesInfo(Message message)
        {
            CreationDate = message.CreationDate;
            Data = message.Data;
            isReaded = message.IsReaded;
            Sender = new UserInfo(message.Sender);
        }
    }
}
