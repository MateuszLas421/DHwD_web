using DHwD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> GetallUser();
        User GetUserByNickName_Token(string NickName, string Token);

    }
}
