using DHwD_web.Data.Interfaces;
using DHwD_web.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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

        public async Task<bool> SaveListOnTheServer(List<Chats> messages)
        {
            bool result=false;
            using (IDbContextTransaction transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    for(int i=0;i<messages.Count;i++)
                        _dbContext.Chats.Add(messages[i]);
                    result = SaveChanges();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                }
            }
            return await Task.FromResult<bool>(result);
        }
    }
}
