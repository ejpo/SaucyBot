using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaucyBot.Model.Shared
{
    class SaucyUserEntity
    {
        [Key]
        public ulong SaucyUserEntityID;
        public ulong DiscordID;
        public ulong GuildID; 
    }
}
