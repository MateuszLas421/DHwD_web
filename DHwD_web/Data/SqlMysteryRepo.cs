using DHwD_web.Data.Interfaces;
using DHwD_web.Helpers;
using Microsoft.EntityFrameworkCore;
using Models.ModelsDB;
using System;
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
