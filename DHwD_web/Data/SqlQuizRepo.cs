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
    public class SqlQuizRepo : IQuizRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlQuizRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Quiz> GetQuizbyIdPlace_Id_Sequence(int Id_Place, int Id_Sequence)
        {
            return await Task.FromResult<Quiz>(await _dbContext.Quizs
                .Where(a => a.Id_Place == Id_Place && a.Sequence == Id_Sequence).FirstOrDefaultAsync());
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
