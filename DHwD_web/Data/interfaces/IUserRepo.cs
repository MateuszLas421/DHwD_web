﻿using DHwD_web.Models;
using System.Collections.Generic;

namespace DHwD_web.Data.Interfaces
{
    public interface IUserRepo : Base.IBaseRepo
    {
        IEnumerable<User> GetallUser();
        User GetUserByNickName_Token(string NickName, string Token);
        bool CreateNewUser(User user);
        User GetUserById(int id);

    }
}
