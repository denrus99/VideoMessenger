using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoMessenger.Models;
using AuthApp.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using Microsoft.EntityFrameworkCore;

namespace VideoMessenger.Controllers
{
    public class ValidationController : Controller
    {
        private ApplicationContext db;

        public ValidationController(ApplicationContext context)
        {
            db = context;
        }

        // Проверка при регистрации на уникальность email
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> UniqueEmail(string email)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.EmailAddress == email);
            if (user != null)
                return Json(false);
            return Json(true);
        }

        // Проверка при регистрации на уникальность phone
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> UniquePhone(string phone)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phone);
            if (user != null)
                return Json(false);
            return Json(true);
        }

        // Проверка при регистрации на уникальность login
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> UniqueLogin(string login)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login);
            if (user != null)
                return Json(false);
            return Json(true);
        }

        // Проверка при авторизации на существование пользователя
        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> ExistEmail(string login)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Login == login);
            if (user == null)
                return Json(false);
            return Json(true);
        }
    }
}
