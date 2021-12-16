using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoMessenger.Models;
using VideoMessenger.ViewModels;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace VideoMessenger.Controllers
{
    public class ChatsController : Controller
    {
        private ApplicationContext db;

        public ChatsController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        [Route("/chat/accept")]
        /* Метод принятия в чат */
        public async Task<IActionResult> AcceptChatInvitation([FromBody] ChatInvitationData data)
        {
            if (data != null)
            {
                if (ModelState.IsValid)
                {
                    var invitation = await db.ChatInvitations.Where(x => x.Recipient.Login == data.RecipientLogin && x.ChatId == data.ChatId).FirstAsync();
                    if (invitation != null)
                    {
                        db.ChatParticipants.Add(new ChatParticipant(invitation.RecipientId, invitation.ChatId, 3));
                        db.ChatInvitations.Remove(invitation);

                        await db.SaveChangesAsync(); // Сохраняем бд
                        return Ok();
                    }

                    return NotFound("The invitation does not exist");
                }
            }
            return BadRequest(data);
        }

        [HttpGet]
        [Route("chats/{id:int}/messages")]
        public async Task<IActionResult> GetChatMessages(int id)
        {       
            var messages = await db.Messages.Include(m=>m.Chat)
                                      .Include(m=>m.Sender)
                                      .Where(m => m.Id == id)
                                      .ToArrayAsync();
            var json = JsonSerializer.Serialize(messages);
            return Ok(json);
        }

        [HttpPut]
        [Route("chats/")]
        public async Task<IActionResult> CreateChat([FromBody] ChatCreationData data)
        {
            if (data != null)
            {
                if (ModelState.IsValid)
                {
                    var time = DateTime.Now;
                    db.Chats.Add(new Chat(data.ChatName, time)); // Создаем новый чат
                    await db.SaveChangesAsync();
                    var sender = await db.Users.FirstOrDefaultAsync(u => u.Login == data.SenderLogin); // Ищем отправителя
                    if (sender != null)
                    {
                        var chatId = db.Chats.FirstOrDefault(u => u.ChatName == data.ChatName && u.CreationDate == time).Id; // Ищем чат в бд и берем Id
                        db.ChatParticipants.Add(new ChatParticipant(sender.Id, chatId, 1)); // Добавлчем отправителя в чат
                        foreach (var login in data.RecipientLogins)
                        {
                            var recipient = await db.Users.FirstOrDefaultAsync(u => u.Login == login); // Ищем пользователя в бд
                            if (recipient != null)
                            {
                                db.ChatInvitations.Add(new ChatInvitation() // Создаем новый инвайт
                                {
                                    SenderId = sender.Id,
                                    ChatId = chatId,
                                    RecipientId = recipient.Id,
                                    CreationDate = DateTime.Now
                                });
                            }
                        }
                        await db.SaveChangesAsync(); // Сохраняем базу данных
                        return Ok();
                    }
                    return NotFound("The sender does not exist");
                }
            }
            return BadRequest(data);
        }
    }
}
