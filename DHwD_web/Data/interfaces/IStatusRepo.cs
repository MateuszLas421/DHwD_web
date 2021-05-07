using Models.ModelsDB;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface IStatusRepo : Base.IBaseRepo
    {
        Status CreateNewStatus(Status status);
        Status UpdateNewStatus(Status status);
        Status GetStatusById(int Id);
        Task<bool> Update(Status status);
    }
}
