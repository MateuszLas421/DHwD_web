using DHwD_web.Dtos;
using DHwD_web.Models;

namespace DHwD_web.Data
{
    public interface IStatusRepo
    {
        Status CreateNewStatus(Status status);
        Status UpdateNewStatus(Status status);
        Status GetStatusById(int Id);
        bool SaveChanges();
    }
}
