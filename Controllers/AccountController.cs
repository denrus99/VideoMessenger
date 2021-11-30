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
        public async Task<IActionResult> Login(LoginModel model)
        {
            // Проверка данных из формы
            if (ModelState.IsValid)
            {
                // Ищем пользователя в базе данных
                var user = await db.Users.FirstOrDefaultAsync(u => u.EmailAddress == model.EmailAddress && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.EmailAddress); // Аутентификация
                    return Ok();
                }

                return NotFound();
            }
            return NotFound();
        }

        // Метод регистрации нового пользователя
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Проверяем уникальность полей
                var user = await db.Users.FirstOrDefaultAsync(u =>
                u.EmailAddress == model.EmailAddress ||
                u.Login == model.Login ||
                u.PhoneNumber == model.PhoneNumber);

                if (user == null)
                {
                    // Добавляем в базу данных
                    db.Users.Add(new User
                    {
                        Login = model.Login,
                        PhoneNumber = model.PhoneNumber,
                        EmailAddress = model.EmailAddress,
                        Password = model.Password
                    });
                    await db.SaveChangesAsync(); // Сохраняем бд

                    await Authenticate(model.EmailAddress); // Аутентификация

                    return Ok();
                }

                return NotFound();
            }
            return NotFound();
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
    }
}