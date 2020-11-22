using DHwD_web.Dtos;
using DHwD_web.Helpers;
using DHwD_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public class SqlPointsRepo:IPointsRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlPointsRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public bool CreatePoints(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool CreatePoints(int id)
        //{
        //    _dbContext.Points.Add()
        //}
    }
}
