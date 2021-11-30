using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoMessenger.Models
{
    public class ChatInvitation
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public int RecipientId { get; set; }
        public User Recipient { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
