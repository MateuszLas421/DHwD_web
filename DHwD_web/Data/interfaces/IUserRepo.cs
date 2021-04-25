using Models.ModelsDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface IUserRepo : Base.IBaseRepo
    {
        IEnumerable<User> GetallUser();
        User GetUserByNickName_Token(string NickName, string Token);
        bool CreateNewUser(User user);
        Task<User> GetUserById(int id);

    }
}
