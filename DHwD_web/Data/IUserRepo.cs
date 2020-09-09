using DHwD.Model;
using System.Collections.Generic;

namespace DHwD_web.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();

        IEnumerable<User> GetallUser();
        User GetUserByNickName_Token(string NickName, string Token);
        void CreateNewUser(User user);

    }
}
