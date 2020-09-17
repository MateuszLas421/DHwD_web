using DHwD_web.Models;
using System.Collections.Generic;
using System.Linq;

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
            var list= _dbContext.Games.ToList();
            if (list.Count()==0)
                return null;
            return list;
        }
        public Games GetGame(int Id) 
        {
            var game = _dbContext.Games.FirstOrDefault(x => x.Id == Id);
            if (game == null)
                return null;
            return game;
        }
        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
    }
}
