using DHwD_web.Data.Interfaces;
using DHwD_web.Helpers;
using DHwD_web.Models;
using Microsoft.EntityFrameworkCore;
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

        public bool CreateNewUser(User user)
        {
            Points points = new Points();
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (GetUserByNickName_Token(user.NickName, user.Token) != null)
                return false;
            _dbContext.Users.Add(user);
            try
            {
                SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            var a = GetUserByNickName_Token(user.NickName, user.Token);
            points.UserId = a.Id;
            points.DataTimeEdit = DateTime.UtcNow;
            points.DataTimeCreate = DateTime.UtcNow;
            _dbContext.Points.Add(points);
            SaveChanges();
            return true;
        }

        public IEnumerable<User> GetallUser()
        {
            return _dbContext.Users.ToList();
        }

        public async Task<User> GetUserById(int id)
        {
            return await Task.FromResult<User> (_dbContext.Users.FirstOrDefault(x => x.Id == id));
        }

        public User GetUserByNickName_Token(string nickName, string token)
        {
            return _dbContext.Users.FirstOrDefault(x => x.NickName == nickName && x.Token == token);
        }

        public bool SaveChanges()
        {
            try
            {
                return (_dbContext.SaveChanges() >= 0);
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
