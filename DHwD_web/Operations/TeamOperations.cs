using DHwD_web.Data.Interfaces;
using Models.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Operations
{
    public static class TeamOperations
    {
        public static bool SetBlocked(List<ActivePlace> activePlacesList, IActivePlacesRepo _activePlacesRepo)
        {
            bool result = false;
            for (int i = 0; i < activePlacesList.Count; i++)
            {
                if (activePlacesList[i].UnlockedPlace != null)
                {
                    int tick = 0;
                    for (int z = 0; z < activePlacesList[i].UnlockedPlace.Length; z++)
                    {
                        if (activePlacesList[i].UnlockedPlace[z] == ';')
                        {
                            var number = Int32.Parse(activePlacesList[i].UnlockedPlace.Substring(tick, z));
                            tick = z + 1;
                            activePlacesList.Where(a => a.ID == number).FirstOrDefault().Blocked = true;
                        }
                    }
                }
            }
            for (int i = 0; i < activePlacesList.Count; i++)
            {
                _activePlacesRepo.Update(activePlacesList[i]);
            }
            return result;
        }
    }
}
