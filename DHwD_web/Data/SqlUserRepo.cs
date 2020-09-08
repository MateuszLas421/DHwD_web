using DHwD.Model;
using DHwD_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlUserRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetallUser()
        {
            return _dbContext.User.ToList();
        }

        public User GetUserByNickName_Token(string nickName, string token)
        {
            return _dbContext.User.FirstOrDefault(x => x.NickName == nickName && x.Token == token);
        }
    }
}
