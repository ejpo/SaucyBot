/**
    This file is Licensed under the MIT Licence
    Copyright (c) 2020 - 2021 Ethan James Patrick O'Donnell

    Authors: ejpo
**/
/// <summary>
/// A genric user class used by the SaucyBot to keep track of any users it needs to for genric classes.
/// SaucyUsers do not maintain much state by design.
/// </summary>
namespace SaucyBot.Shared
{
    public class SaucyUser : BaseSaucyUser
    {
        SaucyUser(ulong userID, ulong guildID)
        {
            Initialization = CreateAsync(userID,guildID);
        }
    }
}