using Models.ModelsDB;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface ILocationRepo : Base.IBaseRepo
    {
        Task<Location> GetLocationById(int id);
    }
}
