using DHwD_web.Models;
using System.Collections.Generic;

namespace DHwD_web.Data.Interfaces
{
    public interface IGamesRepo : Base.IBaseRepo
    {
        IEnumerable<Games> GetallGames();
    }
}
