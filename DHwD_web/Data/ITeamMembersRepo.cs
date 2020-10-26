using DHwD_web.Models;

namespace DHwD_web.Data
{
    public interface ITeamMembersRepo
    {
        bool AddNewMember(TeamMembers item);
        bool Check(TeamMembers item);
        bool CheckOnlyOnePlayer(TeamMembers item);
        bool AddNewMemberNewTeam(TeamMembers item); 
    }
}
