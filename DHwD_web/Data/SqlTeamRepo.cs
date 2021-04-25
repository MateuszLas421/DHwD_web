using DHwD_web.Data.Interfaces;
using DHwD_web.Helpers;
using Microsoft.EntityFrameworkCore;
using Models.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;

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
            //SaveChanges();
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

        public User GetUser(int Id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == Id);
            if (user == null)
                return null;
            return user;
        }
        /// <summary>
        /// Team isn't exist.
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public bool Check(Team team)
        {
            var db = _dbContext.Teams.Where(a => a.Name == team.Name && a.Games.Id == team.Games.Id).FirstOrDefault();
            if (db != null)
                return false;
            return true;
        }

        public IEnumerable<Team> GetTeams(int IdGame)
        {
            var list = _dbContext.Teams.Where(a => a.Games.Id == IdGame).ToList();
            if (list.Count() == 0)
                return null;
            return list;
        }

        public Team GetTeamById(int Id)
        {
            var team = _dbContext.Teams.Where(a => a.Id == Id)
                                 .FirstOrDefault();
            return team;
        }

        public bool CheckPass(int idteam, string hashpass)
        {
            var db = _dbContext.Teams.Where(a => a.Id == idteam && a.Password == hashpass)
                .FirstOrDefault();
            if (db != null)
                return true;
            return false;
        }
    }
}
