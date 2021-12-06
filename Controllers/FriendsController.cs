using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;
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

        [HttpGet]
        [Route("/friend/{login}")]
        public async Task<IActionResult> GetFriends(string login)
        {
            var friends = await db.Friends.Where(x => x.User.Login == login).Include(x => x.Friend).Select(x => x.Friend.Login).ToArrayAsync();
            var json = JsonSerializer.Serialize(friends);
            return Ok(json);
        }

        [HttpPut]
        [Route("/friend/delete")]
        /* Метод удаления из друзей */
        public async Task<IActionResult> DeleteFriend([FromBody] FriendData data)
        {
            if (data != null)
            {
                if (ModelState.IsValid)
                {
                    var friends_1 = await db.Friends.FirstOrDefaultAsync(f => f.User.Login == data.User && f.Friend.Login == data.Friend);
                    var friends_2 = await db.Friends.FirstOrDefaultAsync(f => f.User.Login == data.Friend && f.Friend.Login == data.User);

                    if (friends_1 != null && friends_2 != null)
                    {
                        db.Friends.Remove(friends_1);
                        db.Friends.Remove(friends_2);

                        await db.SaveChangesAsync(); // Сохраняем бд
                        return Ok();
                    }

                    return NotFound("Users are not friends");
                }
            }
            return BadRequest(data);
        }

        [HttpPut]
        [Route("/friend/accept")]
        /* Метод принятия в друзья */
        public async Task<IActionResult> AcceptFriend([FromBody] FriendData data)
        {
            if (data != null)
            {
                if (ModelState.IsValid)
                {
                    var invitation = await db.FriendInvitations.Where(x => x.Sender.Login == data.Friend && x.Recipient.Login == data.User).FirstAsync();            
                    if (invitation != null)
                    {
                        db.Friends.Add(new Friends(invitation.SenderId, invitation.RecipientId));
                        db.Friends.Add(new Friends(invitation.RecipientId, invitation.SenderId));
                        db.FriendInvitations.Remove(invitation);

                        await db.SaveChangesAsync(); // Сохраняем бд
                        return Ok();
                    }

                    return NotFound("The invitation does not exist");
                }
            }
            return BadRequest(data);
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
