using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace VideoMessenger.ViewModels
{
    public class ChatCreationData
    {
        [Required]
        public string ChatName { get; set; }
        [Required]
        public string SenderLogin { get; set; }
        [Required]
        public string[] RecipientLogins { get; set; }
    }
}
