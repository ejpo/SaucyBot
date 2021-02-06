/**
    This file is Licensed under the MIT Licence
    Copyright (c) 2020 - 2021 Ethan James Patrick O'Donnell

    Authors: ejpo
**/

using System.Threading.Tasks;

namespace SaucyBot.Interfaces
{
    interface IAsyncIntialization
    {
        public Task<bool> Initialization
        {
            get;
        }
    }
}
