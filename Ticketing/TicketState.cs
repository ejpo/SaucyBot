/**
    This file is Licensed under the MIT Licence
    Copyright (c) 2020 - 2021 Ethan James Patrick O'Donnell

    Authors: ejpo
**/

using System;
using System.Collections.Generic;
using System.Text;

namespace SaucyBot.Ticketing
{
    enum TicketState
    {
        OPEN,      //0
        CLOSED,    //1
        BLOCKED,   //2
        ABANDONED, //3
        STALE      //4
    }
}
