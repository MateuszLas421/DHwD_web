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

        /// <summary>
        /// Returns the id of active seats for a given team.
        /// </summary>
        /// <param name="teamid"></param>
        /// <returns></returns>
        public async Task<List<int>> GetID_PlacesByTeam_Id(int teamid)
        {
            var activeplace = _dbContext.ActivePlaces
                .Where(a => a.Team_Id == teamid)
                .Include(b => b.Place).ToList();
            List<int> idLocations = new List<int>();
            for (int i = 0; i < activeplace.Count(); i++)
            {
                idLocations.Add(activeplace[i].Place.LocationRef);
            }

            return await Task.FromResult<List<int>>(idLocations);
        }

        public async Task<Place> GetPlace(int numberplace, int gameid)
        {
            Place place = null;
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
        public List<Place> GetPlaceByGameId(int gameid)
        {
            List<Place> result = new List<Place>();

            try
            {
                result =_dbContext.Places
                    .Where(a => a.Games.Id == gameid).ToList<Place>();
            }
            catch (ArgumentNullException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
