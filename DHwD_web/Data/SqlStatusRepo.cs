using DHwD_web.Dtos;
using DHwD_web.Helpers;
using DHwD_web.Models;
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
            return (_dbContext.SaveChanges() >= 0);
        }
        public Status CreateNewStatus(Status status)
        {
            _dbContext.Statuses.Add(status);
            try
            {
                SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
            return status;
        }
        public Status UpdateNewStatus(Status status)
        {
            _dbContext.Statuses.Update(status);
            try
            {
                SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }
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
