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
    public class SqlLocationRepo : ILocationRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlLocationRepo(AppWebDbContext dbContext)
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
        public async Task<Location> GetLocationById(int id)
        {
            var Item = _dbContext.Locations.FirstOrDefault(x => x.ID == id);
            if (Item == null)
                return null;
            return await Task.FromResult(Item);
        }
    }
}
