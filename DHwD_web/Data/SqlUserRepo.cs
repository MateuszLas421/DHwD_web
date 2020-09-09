using DHwD.Model;
using DHwD_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DHwD_web.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlUserRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateNewUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _dbContext.User.Add(user);
        }

        public IEnumerable<User> GetallUser()
        {
            return _dbContext.User.ToList();
        }

        public User GetUserByNickName_Token(string nickName, string token)
        {
            return _dbContext.User.FirstOrDefault(x => x.NickName == nickName && x.Token == token);
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges()>=0);
        }
    }
}
