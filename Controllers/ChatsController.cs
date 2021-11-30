using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoMessenger.Models;
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
            return Ok();
        }
    }
}
