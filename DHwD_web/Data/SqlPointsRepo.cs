using DHwD_web.Data.Interfaces;
using DHwD_web.Helpers;

namespace DHwD_web.Data
{
    public class SqlPointsRepo : IPointsRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlPointsRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
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
