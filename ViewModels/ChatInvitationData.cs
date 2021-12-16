using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoMessenger.ViewModels
{
    public class ChatInvitationData
    {
        [Required]
        public string RecipientLogin { get; set; }
        [Required]
        public int ChatId { get; set; }
    }
}
