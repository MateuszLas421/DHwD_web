using Models.ModelsDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface IPlaceRepo : Base.IBaseRepo
    {
        Task<Place> GetPlace(int numberplace, int gameid);

        Place GetPlaceById(int numberplace, int gameid);

        Task<int> GetID_PlaceByTeam_Id(int teamid);

        IEnumerable<Place> GetPlaceByGameId(int id);

        Task<List<int>> GetID_PlacesByTeam_Id(int teamid);
    }
}
