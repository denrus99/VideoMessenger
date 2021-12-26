using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AuthApp.ViewModels;
using VideoMessenger.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using VideoMessenger.ViewModels;
using System.Linq;
using System.Text.Json;

namespace AuthApp.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationContext db;

        public AccountController(ApplicationContext context)
        {
            db = context;
        }

        // Метод для авторизации пользователя
        [HttpPost]
        [Route("/auth")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Проверка данных из формы
            if (ModelState.IsValid)
            {
                // Ищем пользователя в базе данных
                var user = await db.Users.FirstOrDefaultAsync(u => u.EmailAddress == model.EmailAddress && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.EmailAddress); // Аутентификация
                    return Ok(user);
                }
                return NotFound("The user does not exist");
            }
            return BadRequest(model);
        }

        // Метод регистрации нового пользователя
        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Проверяем уникальность полей
                if (await db.Users.FirstOrDefaultAsync(u => u.EmailAddress == model.EmailAddress) != null)
                    return NotFound("Email is already in use");
                if (await db.Users.FirstOrDefaultAsync(u => u.Login == model.Login) != null)
                    return NotFound("Login is already in use");
                if (await db.Users.FirstOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber) != null)
                    return NotFound("PhoneNumber is already in use");

                var user = new User()
                {
                    Username = model.Login,
                    Login = model.Login,
                    PhoneNumber = model.PhoneNumber,
                    EmailAddress = model.EmailAddress,
                    Password = model.Password
                };

                db.Users.Add(user); // Добавляем в базу данных
                await db.SaveChangesAsync(); // Сохраняем бд
                await Authenticate(model.EmailAddress); // Аутентификация
                return Ok(user);
            }
            return BadRequest(model);
        }

        // Метод аутентификации с помощью Cookies
        private async Task Authenticate(string userName)
        {
            // Создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // Создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // Установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        // Метод выхода
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        [HttpGet]
        [Route("account/{login}/chats")]
        public async Task<IActionResult> Chats(string login)
        {
            if (await db.Users.FirstOrDefaultAsync(u => u.Login == login) == null)
                return NotFound("The user does not exist");

            var res = new List<object>();
            var userParticipations = await db.ChatParticipants.Include(o => o.Chat)
                                           .Include(o => o.User)
                                           .Include(o => o.Role)
                                           .Where(o=>o.User.Login == login)
                                           .ToArrayAsync();
            var chats = new List<Chat>();
            foreach (var participation in userParticipations)
            {
                chats.Add(db.Chats.First(x => x.Id == participation.ChatId));
            }
            foreach (var chat in chats)
            {
                var lastMessage = db.Messages.OrderByDescending(m => m.CreationDate)
                    .Where(m => m.ChatId == chat.Id).FirstOrDefault();
                if (lastMessage != null)
                {
                    var info = new
                    {
                        ChatId = chat.Id,
                        ChatName = chat.ChatName,
                        LastMessage = new 
                        { 
                            Data = lastMessage.Data, 
                            SenderId = lastMessage.SenderId,
                            IsReaded = lastMessage.IsReaded, 
                            CreationDate = lastMessage.CreationDate
                        }
                    };
                    res.Add(info);
                }
                else
                {
                    var info = new
                    {
                        ChatId = chat.Id,
                        ChatName = chat.ChatName,
                        LastMessage = new 
                        { 
                            Data = "В этом чате нет сообщений.", 
                            Sender = "",
                            IsReaded = false.ToString(), 
                            CreationDate = ""
                        }
                    };
                    res.Add(info);
                }
            }
            
            var json = JsonSerializer.Serialize(res);
            return Ok(json);
        }

        [HttpGet]
        [Route("account/{login}")]
        public async Task<IActionResult> User(string login)
        {
            var user = await db.Users.Where(u => u.Login == login).FirstOrDefaultAsync();

            if (user == null)
                return NotFound("The user does not exist");

            return Ok(new UserInfo(user).ToJson());
        }
    }
}