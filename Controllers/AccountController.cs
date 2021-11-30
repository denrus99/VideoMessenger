using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AuthApp.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using VideoMessenger.Models; // моделей базы данных
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

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await db.Users.FirstOrDefaultAsync(u => u.EmailAddress == model.EmailAddress && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.EmailAddress); // аутентификация
                    return Ok();
                }

                return NotFound();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await db.Users.FirstOrDefaultAsync(u =>
                u.EmailAddress == model.EmailAddress ||
                u.Login == model.Login ||
                u.PhoneNumber == model.PhoneNumber);

                if (user == null)
                {
                    db.Users.Add(new User
                    {
                        Login = model.Login,
                        PhoneNumber = model.PhoneNumber,
                        EmailAddress = model.EmailAddress,
                        Password = model.Password
                    });
                    await db.SaveChangesAsync();

                    await Authenticate(model.EmailAddress); // аутентификация

                    return Ok();
                }

                return NotFound();
            }
            return NotFound();
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}