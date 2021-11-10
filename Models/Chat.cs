using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoMessenger.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string ChatName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
