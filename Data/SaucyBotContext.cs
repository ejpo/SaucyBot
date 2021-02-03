using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SaucyBot.Data
{
    class SaucyBotContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) { 
            => options.UseSqlite("Data Source=SaucyBot.db");
        }
    }
}
