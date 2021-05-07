using DHwD_web.Data.Interfaces;
using DHwD_web.Helpers;
using Microsoft.EntityFrameworkCore;
using Models.ModelsDB;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public class SqlStatusRepo : IStatusRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlStatusRepo(AppWebDbContext dbContext)
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

        public Status CreateNewStatus(Status status)
        {
            _dbContext.Statuses.Add(status);
            if (SaveChanges() == false)
                return null;
            return status;
        }

        public Status UpdateNewStatus(Status status)
        {
            _dbContext.Statuses.Update(status);
            if (SaveChanges() == false)
                return null;
            return status;
        }

        public Status GetStatusById(int Id)
        {
            var status = _dbContext.Statuses.Where(a => a.ID == Id)
                                 .FirstOrDefault();
            return status;
        }

        public async Task<bool> Update(Status status)
        {
            _dbContext.Statuses.Update(status);
            return await Task.FromResult<bool>(SaveChanges());
        }
    }
}
