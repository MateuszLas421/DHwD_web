using DHwD.Model;
using DHwD_web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public class SqlTeamRepo : ITeamRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlTeamRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateNewTeam(Team team)
        {
            if (team == null)
            {
                throw new ArgumentNullException(nameof(team));
            }
            var newteam = _dbContext.Games.Where(a => a.Id == team.Games.Id).Include(a => a.Teams).First();
            newteam.Teams.Add(team);
        }
        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

        public User GetUser(int Id)
        {
           var user  =  _dbContext.User.FirstOrDefault(x => x.Id == Id);
            if (user == null)
                return null;
           return user;
        }

        public bool Check(Team team)
        {
            var db = _dbContext.Teams.Where(a => a.Name == team.Name && a.Games.Id==team.Games.Id).FirstOrDefault();
            if(db!=null)
                return false;
            return true;
        }
    }
}
