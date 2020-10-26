using DHwD_web.Models;
using System.Collections.Generic;

namespace DHwD_web.Data
{
    public interface ITeamRepo
    {
        void CreateNewTeam(Team team);
        bool SaveChanges();
        IEnumerable<Team> GetTeams(int IdGame);
        User GetUser(int Id);
        bool Check(Team team);
        Team GetTeamById(int Id);
    }
}
