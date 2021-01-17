using DHwD_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public interface IPlaceRepo
    {
        Task<Place> GetPlace(int numberplace, int gameid);
        Place GetPlaceById(int numberplace, int gameid);
        bool SaveChanges();
    }
}
