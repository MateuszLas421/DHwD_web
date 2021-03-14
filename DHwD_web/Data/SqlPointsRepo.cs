using DHwD_web.Data.interfaces;
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
