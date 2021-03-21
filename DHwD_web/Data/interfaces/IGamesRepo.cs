using DHwD_web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface IGamesRepo : Base.IBaseRepo
    {
        IEnumerable<Games> GetallGames();

        Task<Games> GetGame(int Id);
    }
}
