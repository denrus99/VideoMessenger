using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoMessenger.Models;

namespace VideoMessenger.ViewModels
{
    public class ChatInformation
    {
        public int ChatId { get; set; }
        public string ChatName { get; set; }
        public Message LastMessage { get; set; }
        public Role Role { get; set; }
    }
}
