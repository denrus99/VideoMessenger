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
        public DbSet<Message> Messages { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ChatParticipant>().HasKey(u => new { u.ChatId, u.UserId });
            builder.Entity<Friends>().HasKey(u => new { u.FriendId, u.UserId });
            builder.Entity<User>().HasIndex(u => u.Login).IsUnique();
            builder.Entity<User>().Property(u => u.Login).IsRequired();
            builder.Entity<User>().HasIndex(u => u.PhoneNumber).IsUnique();
            builder.Entity<User>().Property(u => u.PhoneNumber).IsRequired();
            builder.Entity<User>().HasIndex(u => u.EmailAddress).IsUnique();
            builder.Entity<User>().Property(u => u.EmailAddress).IsRequired();
            builder.Entity<User>().Property(u => u.Password).IsRequired();
        }
    }
}
