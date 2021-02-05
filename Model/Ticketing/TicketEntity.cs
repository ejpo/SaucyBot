using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaucyBot.Model.Ticketing
{
    class TicketEntity
    {
        [Key]
        public ulong TicketEntityID { get; set; }
        public ulong TicketEntityLabelID { get; set; } // Label appended to channel
        public ulong TeamEntityID { get; set; } // Foreign Key to TeamEntitys
        public int TicketEntityState { get; set; }
        public UInt64 TicketEntityChannelID { get; set; }
        public DateTime TicketEntityOpenTime { get; set; }
        public DateTime TicketEntityCloseTime { get; set; }
    }
}
