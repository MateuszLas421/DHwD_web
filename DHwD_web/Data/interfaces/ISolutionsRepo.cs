using DHwD_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface ISolutionsRepo : Base.IBaseRepo
    {
        Task<Solutions> GetSolutionsByid(int id);
    }
}
