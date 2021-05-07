using Models.ModelsDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface IActivePlacesRepo : Base.IBaseRepo
    {
        Task<bool> Save(ActivePlace activePlace);

        Task<ActivePlace> GetActivePlacebyID(int IdactivePlace);

        Task<List<ActivePlace>> Get_List_ActivePlacebyTeamID(int Team_Id);

        Task<ActivePlace> CreativeActivePlace(int Team_Id, Place place);

        Task<bool> Update(ActivePlace activePlace);

        Task<ActivePlace> GetActivePlacebyTeamIDandPlaceID(int Id_Team, int Id_Place);

        //Task<ActivePlace> GetActivePlacesByTeamId(int Team_Id);
    }
}
