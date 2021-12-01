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

        [Route("chats/")]
        [HttpPut]
        public async Task<IActionResult> CreateChat([FromBody] ChatCreationData data)
        {
            if (data != null)
            {
                if (ModelState.IsValid)
                {
                    db.Chats.Add(new Chat(data.ChatName, DateTime.Now));
                    var sender = await db.Users.Where(u => u.Login == data.SenderLogin).FirstAsync();
                    if (sender != null)
                    {
                        foreach (var login in data.RecipientLogins)
                        {
                            var recipient = await db.Users.Where(u => u.Login == login).FirstAsync();
                            if (recipient != null)
                            {
                                db.ChatInvitations.Add(new ChatInvitation()
                                {
                                    SenderId = sender.Id,
                                    ChatId = db.Chats.OrderBy(x => x.CreationDate).Last().Id,
                                    RecipientId = recipient.Id,
                                    CreationDate = DateTime.Now
                                });
                            }
                        }
                        await db.SaveChangesAsync(); // Сохраняем бд
                        return Ok();
                    }
                    return NotFound("The sender does not exist");
                }
            }
            return BadRequest(data);
        }
    }
}
