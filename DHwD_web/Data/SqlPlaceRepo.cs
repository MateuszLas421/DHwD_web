using DHwD_web.Data.interfaces;
using DHwD_web.Helpers;
using DHwD_web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public class SqlPlaceRepo : IPlaceRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlPlaceRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public async Task<int> GetID_PlaceByTeam_Id(int teamid)
        {
            var activeplace = _dbContext.ActivePlaces
                .Where(a => a.Team_Id == teamid)
                .Include(b => b.Place).FirstOrDefault();
            int idLocation = activeplace.Place.LocationRef;
            return await Task.FromResult(idLocation);
        }

        public async Task<Place> GetPlace(int numberplace,int gameid)
        {
            Place place=null;
            IEnumerable<Place> result = _dbContext.Places
                .Where(a => a.Games.Id == gameid);
            result.OrderByDescending(s => s.Id).AsQueryable();
            try
            {
                place = result.ElementAt(0);
            }
            catch (ArgumentNullException ex)
            { 
                System.Diagnostics.Debug.WriteLine(ex.Message); 
            }
            catch (ArgumentOutOfRangeException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return await Task.FromResult<Place>(place);
        }

        public Place GetPlaceById(int numberplace, int gameid)
        {
            Place place = null;
            IEnumerable<Place> result = _dbContext.Places
                .Where(a => a.Games.Id == gameid);
            result.OrderByDescending(s => s.Id).AsQueryable();
            try
            {
                place = result.ElementAt(numberplace);
            }
            catch (ArgumentNullException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return place;
        }
    }
}
