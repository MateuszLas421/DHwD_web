using DHwD_web.Helpers;
using DHwD_web.Models;
using System;
using Microsoft.EntityFrameworkCore;
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
            return (_dbContext.SaveChanges() >= 0);
        }
        public Status CreateNewStatus()
        {
            Status status = new Status();
            // var newteam = _dbContext.Statuses.Where();
            //newteam.Add(status);
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
        public Status GetStatusById(int Id)
        {
            var status = _dbContext.Statuses.Where(a => a.ID == Id)
                                 .FirstOrDefault();
            return status;
        }
    }
}
