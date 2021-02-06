/**
    This file is Licensed under the MIT Licence
    Copyright (c) 2020 - 2021 Ethan James Patrick O'Donnell

    Authors: ejpo
**/

using System;
using Discord.WebSocket;

namespace SaucyBot.Events
{
    public class PMArgs : EventArgs
    {
        SocketUserMessage _message;
        SocketUser _user;
        
        public PMArgs (SocketUserMessage message, SocketUser user)
        {
            this._message = message;
            this._user = user;
        }

        public SocketUserMessage Message{
            get{
                return _message;
            }
        }

        public SocketUser User{
            get{
                return _user;
            }
        }
    }


}