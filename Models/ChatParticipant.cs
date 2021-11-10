using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoMessenger.Models
{
    public class ChatParticipant
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
