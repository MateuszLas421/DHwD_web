using Models.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface IQuizRepo : Base.IBaseRepo
    {
        Task<Quiz> GetQuizbyIdPlace_Id_Sequence(int Id_Place, int Id_Sequence);
    }
}
