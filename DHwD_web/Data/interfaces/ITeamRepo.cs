using Models.ModelsDB;
using System.Collections.Generic;

namespace DHwD_web.Data.Interfaces
{
    public interface ITeamRepo : Base.IBaseRepo
    {
        void CreateNewTeam(Team team);
        IEnumerable<Team> GetTeams(int IdGame);
        User GetUser(int Id);  /// to be modified
        bool Check(Team team);
        bool CheckPass(int idteam, string hashpass);
        Team GetTeamById(int Id);
    }
}
