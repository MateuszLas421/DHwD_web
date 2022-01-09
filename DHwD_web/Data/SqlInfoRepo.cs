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
    public class SqlInfoRepo : IInfoRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlInfoRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Info> GetInfo()
        {
            var Item = await _dbContext.Info.OrderBy(x => x.Id).FirstOrDefaultAsync();
            if (Item == null)
                return null;
            return await Task.FromResult(Item);
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
