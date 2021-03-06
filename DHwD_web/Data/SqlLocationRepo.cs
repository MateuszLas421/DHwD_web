﻿using DHwD_web.Data.Interfaces;
using DHwD_web.Helpers;
using Microsoft.EntityFrameworkCore;
using Models.ModelsDB;
using System;
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
            var Item = await _dbContext.Locations.Where(x => x.ID == id).Include(a => a.Place).FirstOrDefaultAsync();
            if (Item == null)
                return null;
            return await Task.FromResult(Item);
        }
    }
}
