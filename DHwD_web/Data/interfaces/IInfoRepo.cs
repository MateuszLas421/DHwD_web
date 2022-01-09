using Models.ModelsDB;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface IInfoRepo : Base.IBaseRepo
    {
        Task<Info> GetInfo();
    }
}
