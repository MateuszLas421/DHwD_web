using DHwD_web.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DHwD_web.Data
{
    public class SqlTeamMembersRepo : ITeamMembersRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlTeamMembersRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
        public bool AddNewMemberNewTeam(TeamMembers item)
        {
            Team newMember = _dbContext.Teams.Where(a => a.Id == item.Team.Id)
                                    .Include(a => a.TeamMembers)
                                    .First();
            newMember.TeamMembers.Add(item);
            SaveChanges();
            User newMemberUser = _dbContext.User.Where(a => a.Id == item.User.Id)
                                       .Include(a => a.TeamMembers)
                                       .First();
            newMemberUser.TeamMembers.Add(item);
            SaveChanges();
            var result = Check(item);
            if (result)
                return true;
            return false;
        }
        public bool AddNewMember(TeamMembers item)
        {
            if (CheckOnlyOnePlayer(item) == true)
                return false;
            Team newMember = _dbContext.Teams.Where(a => a.Id == item.Team.Id)
                                    .Include(a => a.TeamMembers)
                                    .First(); 
            newMember.TeamMembers.Add(item);
            SaveChanges();
            User newMemberUser = _dbContext.User.Where(a => a.Id == item.User.Id)
                                       .Include(a => a.TeamMembers)
                                       .First();
            newMemberUser.TeamMembers.Add(item);
            SaveChanges();
            var result = Check(item);
            if (result)
                return true;
            return false;
        }

        public bool Check(TeamMembers item)
        {
            var db = _dbContext.TeamMembers.Where(a => a.User.Id == item.User.Id && a.Team.Id == item.Team.Id)
                            .FirstOrDefault();
            if (db != null)
                return true;
            return false;
        }

        public bool CheckOnlyOnePlayer(TeamMembers item)
        {
            var team = _dbContext.Teams.Where(a => a.Id == item.Team.Id)
                     .FirstOrDefault();
            return team.OnlyOnePlayer;
        }
    }
}
