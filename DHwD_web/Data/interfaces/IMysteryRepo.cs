using Models.ModelsDB;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface IMysteryRepo : Base.IBaseRepo
    {
        Task<Mysterys> GetMysteryById(int id);
    }
}
