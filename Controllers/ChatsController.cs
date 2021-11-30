using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoMessenger.Controllers
{
    public class ChatsController : Controller
    {
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
