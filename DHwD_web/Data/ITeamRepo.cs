using DHwD_web.Models;
using System.Collections.Generic;

namespace DHwD_web.Data
{ 
    public interface ITeamRepo
    {
        void CreateNewTeam(Team team);
        bool SaveChanges();
        IEnumerable<Team> GetTeams(int IdGame);
        User GetUser(int Id);  /// to be modified
        bool Check(Team team);
        bool CheckPass(int idteam,string hashpass);
        Team GetTeamById(int Id);
    }
}
