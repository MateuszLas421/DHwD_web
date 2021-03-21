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
    public class SqlChats : IChatsRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlChats(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> SaveOnTheServer(Chats message)
        {
            _dbContext.Chats.Add(message);
            return await Task.FromResult<bool>(SaveChanges());
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
