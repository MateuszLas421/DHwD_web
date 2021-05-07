using Models.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Operations
{
    public class ActivePlacesOperations
    {
        public Task<Status> Update_ActivePlace_in_Status(Status status, string activeplacestring)
        {
            var position = status.List_Id_ActivePlace.IndexOf(activeplacestring);
            if (position == 0)
            {
                status.List_Id_ActivePlace = status.List_Id_ActivePlace.Substring(position + 1);
            }
            else
            {
                activeplacestring = ";" + activeplacestring;
                position = status.List_Id_ActivePlace.IndexOf(activeplacestring);
                status.List_Id_ActivePlace = status.List_Id_ActivePlace.Substring(0, position + 1);
            }
            return Task.FromResult<Status>(status);
        }
    }
}
