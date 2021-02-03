using System;
using System.Collections.Generic;
using System.Text;

namespace SaucyBot.Model.Ticketing
{
    class TicketEntity
    {
        public ulong TicketEntityID;
        public ulong TicketEntityLabelID; // Label appended to channell
        public ulong TeamEntityID; //Foreign Key to TeamEntitys
        public int TicketEntityState;
        public UInt64 TicketEntityChannelID;
        public DateTime TicketEntityOpenTime;
        public DateTime TicketEntityCloseTime;
    }
}
