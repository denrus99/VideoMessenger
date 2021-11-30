using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoMessenger.Models;

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
            return Content(id.ToString());
        }
    }
}
