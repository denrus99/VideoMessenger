using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoMessenger.Models;
using VideoMessenger.ViewModels;

namespace VideoMessenger.Controllers
{
    public class FriendsController : Controller
    {
        private ApplicationContext db;

        public FriendsController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        [Route("friend/invite")]
        /* Метод для отправления заявки в друзья */
        public async Task<IActionResult> SendInvitationFriend([FromBody] FriendInvitationData data)
        {
            if (data != null)
            {
                if (ModelState.IsValid)
                {
                    var time = DateTime.Now;
                    var sender = await db.Users.FirstOrDefaultAsync(u => u.Login == data.SenderLogin);
                    if (sender == null)
                        return NotFound("The sender does not exist");
                    var recipient = await db.Users.FirstOrDefaultAsync(u => u.Login == data.RecipientLogin);
                    if (recipient == null)
                        return NotFound("The recipient does not exist");

                    db.FriendInvitations.Add(new FriendInvitation()
                    {
                        SenderId = sender.Id,
                        RecipientId = recipient.Id,
                        CreationDate = DateTime.Now
                    });

                    await db.SaveChangesAsync(); // Сохраняем бд
                    return Ok();
                }
            }
            return BadRequest(data);
        }
    }
}
