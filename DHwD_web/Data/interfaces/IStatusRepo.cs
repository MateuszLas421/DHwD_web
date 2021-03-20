using DHwD_web.Dtos;
using DHwD_web.Models;

namespace DHwD_web.Data.Interfaces
{
    public interface IStatusRepo : Base.IBaseRepo
    {
        Status CreateNewStatus(Status status);
        Status UpdateNewStatus(Status status);
        Status GetStatusById(int Id);
    }
}
