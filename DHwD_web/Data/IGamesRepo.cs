using DHwD_web.Models;
using System.Collections.Generic;

namespace DHwD_web.Data
{
    public interface IGamesRepo
    {
        IEnumerable<Games> GetallGames();
        bool SaveChanges();
    }
}
