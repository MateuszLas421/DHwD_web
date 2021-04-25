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
    public class SqlGamesRepo : IGamesRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlGamesRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Games> GetallGames()
        {
            DateTime time = DateTime.UtcNow;
            var list = _dbContext.Games
                .Where(a => a.DateTimeStart < time.AddDays(+7) && a.DateTimeEnd > time.AddHours(+1))
                .ToList();
            if (list.Count() == 0)
                return null;
            return list;
        }
        public async Task<Games> GetGame(int Id)
        {
            var game = _dbContext.Games.FirstOrDefault(x => x.Id == Id);
            if (game == null)
                return null;
            return await Task.FromResult<Games>(game);
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
