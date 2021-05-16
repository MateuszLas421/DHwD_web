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
    public class SqlMurdererMessagesRepo : IMurdererMessagesRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlMurdererMessagesRepo(AppWebDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MurdererMessages>> GetListByPlaceID(int Id_Place, int type)
        {
            List<MurdererMessages> messageslist = new List<MurdererMessages>();
            try
            {
                messageslist = _dbContext.MurdererMessages
                .Where(a => a.Id_Place == Id_Place && a.TypeMessage == type).ToList();
            }
            catch (ArgumentNullException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            if (messageslist == null)
                return null;
            return await Task.FromResult<List<MurdererMessages>>(messageslist);
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
