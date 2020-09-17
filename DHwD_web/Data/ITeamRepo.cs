using DHwD.Model;
using DHwD_web.Models;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public interface ITeamRepo
    {
        void CreateNewTeam(Team team);
        bool SaveChanges();
        User GetUser(int Id);
    }
}
