using DHwD_web.Models;
using System.Threading.Tasks;

namespace DHwD_web.Data.interfaces
{
    public interface IActivePlacesRepo
    {
        Task<bool> Save(ActivePlace activePlace);

        Task<ActivePlace> GetActivePlacebyID(int IdactivePlace);

        Task<ActivePlace> GetActivePlacebyTeamIDandActive(int Team_Id);

        Task<ActivePlace> CreativeActivePlace(int Team_Id, Place place);

        //Task<ActivePlace> GetActivePlacesByTeamId(int Team_Id);

        bool SaveChanges();
    }
}
