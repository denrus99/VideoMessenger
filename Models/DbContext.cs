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
        public DbSet<User> User { get; set; }
        public DbSet<Friends> Friends { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<ChatParticipant> ChatParticipant { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Role> Role { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ChatParticipant>().HasKey(u => new { u.ChatId, u.UserId });
            builder.Entity<Friends>().HasKey(u => new { u.FriendId, u.UserId });
        }
    }
}
