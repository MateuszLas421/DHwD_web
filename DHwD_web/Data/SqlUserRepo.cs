using DHwD_web.Helpers;
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
            Points points = new Points();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _dbContext.Users.Add(user);
            SaveChanges();
            var a = GetUserByNickName_Token(user.NickName, user.Token);
            points.UserId = a.Id;
            points.DataTimeEdit = DateTime.UtcNow;
            points.DataTimeCreate = DateTime.UtcNow;
            _dbContext.Points.Add(points);
            SaveChanges();
        }

        public IEnumerable<User> GetallUser()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByNickName_Token(string nickName, string token)
        {
            return _dbContext.Users.FirstOrDefault(x => x.NickName == nickName && x.Token == token);
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges()>=0);
        }
    }
}
