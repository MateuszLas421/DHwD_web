using DHwD_web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public interface ITeamMembersRepo
    {
        bool AddNewMember(TeamMembers item);
        bool Check(TeamMembers item);
        bool CheckOnlyOnePlayer(TeamMembers item);
        bool AddNewMemberNewTeam(TeamMembers item);
        TeamMembers GetMyTeams(int Id, int UserId);
        IEnumerable<TeamMembers> GetTeams(int IdGame);
    }
}

