using Models.ModelsDB;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface ISolutionsRepo : Base.IBaseRepo
    {
        Task<Solutions> GetSolutionsByid(int id);
    }
}
