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
                    var time = DateTime.Now;
                    db.Chats.Add(new Chat(data.ChatName, time));
                    await db.SaveChangesAsync();
                    var sender = await db.Users.FirstOrDefaultAsync(u => u.Login == data.SenderLogin);
                    if (sender != null)
                    {
                        foreach (var login in data.RecipientLogins)
                        {
                            var recipient = await db.Users.FirstOrDefaultAsync(u => u.Login == login);
                            if (recipient != null)
                            {
                                db.ChatInvitations.Add(new ChatInvitation()
                                {
                                    SenderId = sender.Id,
                                    ChatId = db.Chats.FirstOrDefault(u => u.ChatName == data.ChatName && u.CreationDate == time).Id,
                                    RecipientId = recipient.Id,
                                    CreationDate = DateTime.Now
                                });
                            }
                        }
                        await db.SaveChangesAsync();
                        return Ok();
                    }
                    return NotFound("The sender does not exist");
                }
            }
            return BadRequest(data);
        }
    }
}
