using DHwD_web.Data.Interfaces;
using DHwD_web.Helpers;
using Microsoft.EntityFrameworkCore;
using Models.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public class SqlActivePlacesRepo : IActivePlacesRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlActivePlacesRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Save(ActivePlace activePlace)
        {
            activePlace.Active = false;
            _dbContext.ActivePlaces.Add(activePlace);
            return await Task.FromResult<bool>(SaveChanges());
        }

        public async Task<bool> Update(ActivePlace activePlace)
        {
            _dbContext.ActivePlaces.Update(activePlace);
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
            if (activePlace == null)
                return null;
            return await Task.FromResult<ActivePlace>(activePlace);
        }

        public async Task<List<ActivePlace>> Get_List_ActivePlacebyTeamID(int Team_Id)
        {
            List<ActivePlace> activePlace = new List<ActivePlace>();
            try
            {
                activePlace = _dbContext.ActivePlaces
                .Where(a => a.Active == true && a.Team_Id == Team_Id).ToList<ActivePlace>();
            }
            catch (ArgumentNullException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            if (activePlace == null)
                return null;
            return await Task.FromResult<List<ActivePlace>>(activePlace);
        }

        public async Task<ActivePlace> CreativeActivePlace(int Team_Id, Place place)
        {
            ActivePlace activePlace = new ActivePlace(Team_Id, place);
            activePlace.Active = true;
            activePlace.UnlockedPlace = place.UnlockedPlace;
            activePlace.Required = place.Required;
            activePlace.IsEndPlace = place.IsEndPlace;
            _dbContext.ActivePlaces.Add(activePlace);
            SaveChanges();
            return await Task.FromResult<ActivePlace>(activePlace);
        }

        public async Task<ActivePlace> GetActivePlacebyTeamIDandPlaceID(int Id_Team, int Id_Place)
        {
            ActivePlace activePlace = new ActivePlace();
            try
            {
                activePlace = await _dbContext.ActivePlaces
                .Where(a => a.Place.Id == Id_Place && a.Team_Id == Id_Team)
                .Include(a => a.Place)
                .FirstOrDefaultAsync();
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
        /// <summary>
        /// CheckActivePlace search for active places 
        /// </summary>
        /// <param name="Id_Team"></param>
        /// <returns>(true == clear)</returns>
        public async Task<bool> CheckActivePlace(int Id_Team)
        {
            ActivePlace activePlace = new ActivePlace();
            try
            {
                activePlace = await _dbContext.ActivePlaces
                .Where(a => a.Active==true && a.Team_Id == Id_Team)
                .Include(a => a.Place)
                .FirstOrDefaultAsync();
            }
            catch (ArgumentNullException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            if (activePlace != null)
                return await Task.FromResult<bool>(false);
            return await Task.FromResult<bool>(true);

        }
    }
}
