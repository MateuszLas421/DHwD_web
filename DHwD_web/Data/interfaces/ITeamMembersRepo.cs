using DHwD_web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface ITeamMembersRepo : Base.IBaseRepo
    {
        bool AddNewMember(TeamMembers item);
        bool Check(TeamMembers item);
        bool CheckOnlyOnePlayer(TeamMembers item);
        bool AddNewMemberNewTeam(TeamMembers item);
        Task<TeamMembers> GetMyTeams(int Id, int UserId);
        IEnumerable<TeamMembers> GetTeamMembers(int IdTeam);
    }
}

