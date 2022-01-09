using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoMessenger.Models;

namespace VideoMessenger.ViewModels
{
    public class InvitationInfo
    {
        public int ChatId { get; set; }
        public string ChatName { get; set; }
        public UserInfo Sender { get; set; }
        public UserInfo Recipient { get; set; }
        public DateTime CreationDate { get; set; }

        public InvitationInfo(ChatInvitation invitation)
        {
            ChatId = invitation.ChatId;
            ChatName = invitation.Chat.ChatName;
            Sender = new UserInfo(invitation.Sender);
            Recipient = new UserInfo(invitation.Recipient);
            CreationDate = invitation.CreationDate;
        }
    }
}
