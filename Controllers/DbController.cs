using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using VideoMessenger.Models;
using Microsoft.AspNetCore.Hosting;

namespace VideoMessenger.Controllers
{
    public class DbController : Controller
    {
        private readonly ApplicationContext db;

        public DbController(IWebHostEnvironment environment)
        {
            var config = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath).AddJsonFile("dbsettings.json").Build();
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseNpgsql(config.GetConnectionString("DefaultConnection"))
                .Options;
            db = new ApplicationContext(options);
        }

        // GET: DbController
        public ActionResult Index()
        {
            return View();
        }

        // POST: DbController/AddUser
        [HttpPost]
        public void AddUser(string username, string login)
        {
            var baba = username;
            //var user = new User()
            //{
            //    Username = username,
            //    Login = login,
            //    Password = password,
            //    PhoneNumber = phone,
            //    EmailAddress = email
            //};
            //db.User.Add(user);
            //db.SaveChanges();
        }
    }
}
