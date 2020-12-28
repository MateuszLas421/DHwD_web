using DHwD_web.Helpers;
using DHwD_web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public class SqlActivePlacesRepo: IActivePlacesRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlActivePlacesRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Save(ActivePlace activePlace)
        {
            activePlace.Active = true;
            _dbContext.ActivePlaces.Add(activePlace); 
            return await Task.FromResult<bool>(SaveChanges()); 
        }
        public async Task<ActivePlace> GetActivePlacebyID(int IdactivePlace)
        {
            ActivePlace activePlace = null;         
            try
            {
                activePlace = _dbContext.ActivePlaces
                .Where(a => a.ID == IdactivePlace).FirstOrDefault();
            }
            catch (ArgumentNullException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            if(activePlace == null)
                return null;
            return await Task.FromResult<ActivePlace>(activePlace);
        }
        public async Task<ActivePlace> GetActivePlacebyTeamIDandActive(int Team_Id)
        {
            ActivePlace activePlace = null;
            try
            {
                activePlace = _dbContext.ActivePlaces
                .Where(a => a.Active==true && a.Team_Id==Team_Id).FirstOrDefault();
            }
            catch (ArgumentNullException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            if (activePlace == null)
                return null;
            return await Task.FromResult<ActivePlace>(activePlace);
        }
        public bool SaveChanges()
        {
            try
            {
                return (_dbContext.SaveChanges() >= 0);
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
