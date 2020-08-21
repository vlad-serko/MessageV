using MessageV.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageV.Infrastructure.Data
{
    public class ChatContext : DbContext
    {
        public DbSet<Chat> Chats { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserChat> UserChats { get; set; }

        public DbSet<Message> Messages { get; set; }


        public ChatContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserChat>()
                .HasKey(x => new { x.ChatId, x.UserId });
        }


    }
}