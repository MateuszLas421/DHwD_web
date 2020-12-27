using DHwD_web.Helpers;
using DHwD_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public class SqlPlaceRepo:IPlaceRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlPlaceRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }
    }
}
