using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VideoMessenger.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatParticipant> ChatParticipants { get; set; }
        public DbSet<ChatInvitation> ChatInvitations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ChatParticipant>().HasKey(u => new { u.ChatId, u.UserId }); // Составной ключ
            builder.Entity<Friends>().HasKey(u => new { u.FriendId, u.UserId }); 

            builder.Entity<User>().HasIndex(u => u.Login).IsUnique(); // Унимкальность поля
            builder.Entity<User>().Property(u => u.Login).IsRequired(); // атрибут NOT NULL
            builder.Entity<User>().HasIndex(u => u.PhoneNumber).IsUnique();
            builder.Entity<User>().Property(u => u.PhoneNumber).IsRequired();
            builder.Entity<User>().HasIndex(u => u.EmailAddress).IsUnique();
            builder.Entity<User>().Property(u => u.EmailAddress).IsRequired();
            builder.Entity<User>().Property(u => u.Password).IsRequired();

            builder.Entity<ChatParticipant>().Property(u => u.ChatId).IsRequired();
            builder.Entity<ChatParticipant>().Property(u => u.UserId).IsRequired();
            builder.Entity<ChatParticipant>().Property(u => u.RoleId).IsRequired();

            builder.Entity<Friends>().Property(u => u.UserId).IsRequired();
            builder.Entity<Friends>().Property(u => u.FriendId).IsRequired();

            builder.Entity<Role>().Property(u => u.Name).IsRequired();

            builder.Entity<Message>().Property(u => u.SenderId).IsRequired();
            builder.Entity<Message>().Property(u => u.ChatId).IsRequired();

            builder.Entity<ChatInvitation>().Property(u => u.SenderId).IsRequired();
            builder.Entity<ChatInvitation>().Property(u => u.RecipientId).IsRequired();
            builder.Entity<ChatInvitation>().Property(u => u.ChatId).IsRequired();

            builder.Entity<Role>().HasData( // Добавление тестовых данных в бд
                new Role("creator", 1),
                new Role("moderator", 2),
                new Role("user", 3)
                );

            builder.Entity<User>().HasData(
                new User() { Id = -1, Username = "Vasya", Login = "Pupok", EmailAddress = "vasia322@bbqqkk.com", Password = "ahc4ahlv4lt", PhoneNumber = "+78222345678" },
                new User() { Id = -2,Username = "Igor", Login = "Uxo", EmailAddress = "igor228@bbqqkk.com", Password = "aklovfaoper", PhoneNumber = "+79221234564" },
                new User() { Id = -3,Username = "Masha", Login = "Davalka", EmailAddress = "openheart@bbqqkk.com", Password = "12345", PhoneNumber = "+78921234567" });

            builder.Entity<Friends>().HasData(
                new Friends(-1, -2),
                new Friends(-2, -1),
                new Friends(-1, -3),
                new Friends(-3, -1)
                );

            builder.Entity<Chat>().HasData(
                new Chat("RI-390003", DateTime.Now, -1),
                new Chat("Gamers Room", DateTime.Now.AddDays(2), -2)
                );

            builder.Entity<Message>().HasData(
                new Message() { Id = -1, SenderId = -1, ChatId= -1, Data="Hello, World!", CreationDate=DateTime.Now, IsReaded=false },
                new Message() { Id = -2, SenderId = -2, ChatId= -2, Data="Good bye, World!", CreationDate=DateTime.Now.AddDays(2), IsReaded=true },
                new Message() { Id = -3, SenderId = -3, ChatId= -2, Data="My life be like, uuuuaaaa", CreationDate=DateTime.Now.AddHours(3), IsReaded=false }
                );
        }
    }
}
