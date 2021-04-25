using DHwD_web.Data.Interfaces;
using DHwD_web.Helpers;
using Microsoft.EntityFrameworkCore;
using Models.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public class SqlChatsRepo : IChatsRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlChatsRepo(AppWebDbContext dbContext)
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

        public async Task<IEnumerable<Chats>> GetChat(int gameid, int teamId)
        {
            var items = await _dbContext.Chats
                .Where(a => a.Team.Id == teamId && a.Game.Id == gameid).ToListAsync();
            if (items.Count() == 0)
                return null;
            return await Task.FromResult<IEnumerable<Chats>>(items);
        }
    }
}
