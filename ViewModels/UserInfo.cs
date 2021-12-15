using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoMessenger.Models;
using System.Text.Json;

namespace VideoMessenger.ViewModels
{
    public class UserInfo
    {
        public string Username { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public UserInfo(User user)
        {
            Username = user.Username;
            Login = user.Login;
            Email = user.EmailAddress;
            PhoneNumber = user.PhoneNumber;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
