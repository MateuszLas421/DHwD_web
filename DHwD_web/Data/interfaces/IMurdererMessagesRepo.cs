using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.ModelsDB;

namespace DHwD_web.Data.Interfaces
{
    public interface IMurdererMessagesRepo : Base.IBaseRepo
    {
        Task<List<MurdererMessages>> GetListByPlaceID(int Id_Place, int type);
    }
}
