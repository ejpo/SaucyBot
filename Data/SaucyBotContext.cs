using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SaucyBot.Model.Shared;
using SaucyBot.Model.Ticketing;

namespace SaucyBot.Data
{
    class SaucyBotContext : DbContext
    {
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<SaucyUserEntity> Users { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=SaucyBot.db");
    }
}
