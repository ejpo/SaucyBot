using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaucyBot.Model.Ticketing
{
    class TicketEntity
    {
        [Key]
        public ulong TicketEntityID;
        public ulong TicketEntityLabelID; // Label appended to channel
        public ulong TeamEntityID; // Foreign Key to TeamEntitys
        public int TicketEntityState;
        public UInt64 TicketEntityChannelID;
        public DateTime TicketEntityOpenTime;
        public DateTime TicketEntityCloseTime;
    }
}
