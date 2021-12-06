using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoMessenger.ViewModels
{
    public class FriendData
    {
        [Required]
        public string User { get; set; }
        [Required]
        public string Friend { get; set; }
    }
}
