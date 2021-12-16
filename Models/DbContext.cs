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
        public DbSet<FriendInvitation> FriendInvitations { get; set; }
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

            builder.Entity<FriendInvitation>().Property(u => u.SenderId).IsRequired();
            builder.Entity<FriendInvitation>().Property(u => u.RecipientId).IsRequired();

            builder.Entity<Role>().HasData( // Добавление тестовых данных в бд
                new Role("creator", 1),
                new Role("moderator", 2),
                new Role("user", 3)
                );

            builder.Entity<User>().HasData(
                new User() { Id = -1, Username = "Vasya", Login = "Pupok", EmailAddress = "vasya322@ya.ru", Password = "ahc4ahlv4lt", PhoneNumber = "+78222345678" },
                new User() { Id = -2, Username = "Igor", Login = "Uxo", EmailAddress = "igor2005@ya.ru", Password = "aklovfaoper", PhoneNumber = "+79221234564" },
                new User() { Id = -3, Username = "Masha", Login = "Poland", EmailAddress = "sodeep@ya.ru", Password = "12345", PhoneNumber = "+78921234567" });

            builder.Entity<Friends>().HasData(
                new Friends(-1, -2),
                new Friends(-2, -1),
                new Friends(-1, -3),
                new Friends(-3, -1)
                );

            builder.Entity<Chat>().HasData(
                new Chat("RI-390003", new DateTime(2021, 12, 16, 13, 16, 0, 0, DateTimeKind.Local), -1),
                new Chat("Gamers Room", new DateTime(2021, 12, 2, 20, 16, 11, 191, DateTimeKind.Local), -2)
                );

            builder.Entity<Message>().HasData(
                new Message() { Id = -1, SenderId = -1, ChatId= -1, Data="Привет, как у вас дела?", CreationDate= new DateTime(2021, 12, 16, 13, 16, 10, 191, DateTimeKind.Local), IsReaded = true },
                new Message() { Id = -2, SenderId = -2, ChatId= -1, Data="Привет, нормально", CreationDate= new DateTime(2021, 12, 16, 13, 16, 12, 191, DateTimeKind.Local), IsReaded = true },
                new Message() { Id = -3, SenderId = -3, ChatId= -1, Data="Отлично! Как у тебя?", CreationDate= new DateTime(2021, 12, 16, 13, 16, 14, 191, DateTimeKind.Local), IsReaded = true },
                new Message() { Id = -4, SenderId = -1, ChatId= -1, Data="Могло быть и лучше", CreationDate= new DateTime(2021, 12, 16, 13, 16, 16, 191, DateTimeKind.Local), IsReaded = true },
                new Message() { Id = -5, SenderId = -2, ChatId= -1, Data="Что случилось?", CreationDate= new DateTime(2021, 12, 16, 13, 16, 20, 191, DateTimeKind.Local), IsReaded = true },
                new Message() { Id = -6, SenderId = -1, ChatId= -1, Data="Получил 4 по алгебре", CreationDate= new DateTime(2021, 12, 16, 13, 16, 25, 191, DateTimeKind.Local), IsReaded = true },
                new Message() { Id = -7, SenderId = -3, ChatId= -1, Data="У меня вообще тройка, не стоит отчаиваться", CreationDate= new DateTime(2021, 12, 16, 13, 16, 30, 191, DateTimeKind.Local), IsReaded = true },
                new Message() { Id = -8, SenderId = -2, ChatId= -1, Data="Нормально все будет", CreationDate= new DateTime(2021, 12, 16, 13, 16, 35, 191, DateTimeKind.Local), IsReaded = true },
                new Message() { Id = -9, SenderId = -3, ChatId= -1, Data="Приезжайте ко мне, будем в шашки играть", CreationDate= new DateTime(2021, 12, 16, 13, 16, 36, 191, DateTimeKind.Local), IsReaded = true },
                new Message() { Id = -10, SenderId = -1, ChatId= -1, Data="Выезжаю...", CreationDate= new DateTime(2021, 12, 1, 13, 16, 38, 191, DateTimeKind.Local), IsReaded = false },
                new Message() { Id = -11, SenderId = -2, ChatId= -2, Data="Good bye, World!", CreationDate= new DateTime(2021, 12, 2, 20, 16, 11, 191, DateTimeKind.Local), IsReaded = true },
                new Message() { Id = -12, SenderId = -3, ChatId= -2, Data="My life be like, uuuuaaaa", CreationDate= new DateTime(2021, 12, 2, 21, 16, 11, 191, DateTimeKind.Local), IsReaded = false }
                );

            builder.Entity<ChatParticipant>().HasData(
                new ChatParticipant(-1, -1, 1),
                new ChatParticipant(-2, -1, 2),
                new ChatParticipant(-3, -1, 3),
                new ChatParticipant(-2, -2, 1),
                new ChatParticipant(-1, -2, 2)
                );
        }
    }
}
