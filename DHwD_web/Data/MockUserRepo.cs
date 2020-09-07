using DHwD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public class MockUserRepo : IUserRepo
    {
        public User GetUserByNickName_Token(string NickName, string Token)
        {
            throw new System.NotImplementedException();
        }
    }
}
