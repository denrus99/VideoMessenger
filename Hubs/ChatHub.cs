using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using VideoMessenger.Models;

namespace SignalRtcHubs
{
    public class ChatHub : Hub
    {
        private static Dictionary<string, List<string>> chats;
        private ApplicationContext db;

        public ChatHub(ApplicationContext context)
        {
            chats = new Dictionary<string, List<string>>();
            db = context;
        }

        public async Task JoinChat(int chatId, string login)
        {
            if (IsChatParticipant(login, chatId))
            {
                if (!chats.ContainsKey(chatId.ToString()))
                {
                    chats.Add(chatId.ToString(), new List<string>());
                }
                chats[chatId.ToString()].Add(Context.ConnectionId);
                await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
            }
        }

        public async Task SendMessage(string text, string login, int chatId)
        {
            if (IsChatParticipant(login, chatId))
            {
                int newId = db.Messages.Count();
                User sender = db.Users.First(x => x.Login == login);
                Chat chat = db.Chats.First(x => x.Id == chatId);
                Message message = new Message(newId, sender.Id, sender, chat.Id, chat, text);
                db.Messages.Add(message);
                await Clients.Group(chatId.ToString()).SendAsync("AcceptMessage", message);
                await db.SaveChangesAsync();
            }
        }

        private bool IsChatParticipant(string login, int chatId)
        {
            Chat chat = db.Chats.First(x => x.Id == chatId);
            ChatParticipant cp = db.ChatParticipants.FirstOrDefault(x => x.ChatId == chatId && x.User.Login == login);
            return cp != null;
        }
    }
}