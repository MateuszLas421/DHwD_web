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
    public class SqlMysteryRepo : IMysteryRepo
    {
        private readonly AppWebDbContext _dbContext;
        public async Task<Mysterys> GetMysteryById(int id)
        {
            var mystery = await _dbContext.Mysterys.FirstOrDefaultAsync(x => x.ID == id);
            return await Task.FromResult(mystery);
        }

        public SqlMysteryRepo(AppWebDbContext dbContext)
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
    }
}
