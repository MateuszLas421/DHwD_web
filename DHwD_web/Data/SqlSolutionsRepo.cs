﻿using DHwD_web.Data.Interfaces;
using DHwD_web.Helpers;
using Microsoft.EntityFrameworkCore;
using Models.ModelsDB;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public class SqlSolutionsRepo : ISolutionsRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlSolutionsRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Solutions> GetSolutionsByid(int id)
        {
            var result = await _dbContext.Solutions.Where(a => a.ID == id).FirstOrDefaultAsync();
            return await Task.FromResult(result);
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
