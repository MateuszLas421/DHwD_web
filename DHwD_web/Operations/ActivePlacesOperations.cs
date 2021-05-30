using DHwD_web.Data.Interfaces;
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
            var position = status.List_Id_Required_Pleaces_To_End.IndexOf(activeplacestring);
            if(status.List_Id_Required_Pleaces_To_End == String.Empty || position == -1)
                return Task.FromResult<Status>(status);
            position = status.List_Id_Required_Pleaces_To_End.IndexOf(activeplacestring);
            status.List_Id_Required_Pleaces_To_End = status.List_Id_Required_Pleaces_To_End.Remove(position, activeplacestring.Length);
            return Task.FromResult<Status>(status);
        }

        public async Task<bool> Update_Unblocked_Activ_Place(IActivePlacesRepo _activePlacesRepo, ActivePlace Item, int Id_Team)
        {
            var tempstring = Item.UnlockedPlace;
            int position;
            try
            {
                while (tempstring.Contains(";"))
                {
                    position = tempstring.IndexOf(";");
                    var Id_temp = tempstring.Substring(0,position);
                    var Object_temp = await _activePlacesRepo.GetActivePlacebyTeamIDandPlaceID(Id_Team, Int32.Parse(Id_temp));
                    if (Object_temp != null)
                    {
                        Object_temp.Blocked = false;
                        if (!(await _activePlacesRepo.Update(Object_temp)))
                            return await Task.FromResult(false);
                    }
                    tempstring = tempstring.Substring(position + 1);
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
            return await Task.FromResult<bool>(true);
        }
    }
}
