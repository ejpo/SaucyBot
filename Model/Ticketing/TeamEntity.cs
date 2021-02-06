using System;
using SaucyBot.Ticketing;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SaucyBot.Model.Ticketing
{
    class TeamEntity
    {
        [Key]
        public ulong TeamEntityID { get; set; }
        public ulong TeamEntityDiscordID { get; set; }
        public String TeamEntityName { get; set; }
        public ulong TeamEntityGuildID { get; set; }
    }
}
