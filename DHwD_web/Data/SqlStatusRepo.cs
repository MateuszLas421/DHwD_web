using DHwD_web.Data.interfaces;
using DHwD_web.Helpers;
using DHwD_web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
    }
}
