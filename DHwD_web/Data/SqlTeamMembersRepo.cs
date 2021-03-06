﻿using DHwD_web.Data.Interfaces;
using DHwD_web.Helpers;
using Microsoft.EntityFrameworkCore;
using Models.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Data
{
    public class SqlTeamMembersRepo : ITeamMembersRepo
    {
        private readonly AppWebDbContext _dbContext;

        public SqlTeamMembersRepo(AppWebDbContext dbContext)
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

        public bool AddNewMemberNewTeam(TeamMembers item)
        {
            Team newMember = _dbContext.Teams.Where(a => a.Id == item.Team.Id)
                                    .Include(a => a.TeamMembers)
                                    .First();
            newMember.TeamMembers.Add(item);
            SaveChanges();
            User newMemberUser = _dbContext.Users.Where(a => a.Id == item.User.Id)
                                       .Include(a => a.TeamMembers)
                                       .First();
            newMemberUser.TeamMembers.Add(item);
            SaveChanges();
            var result = Check(item);
            if (result)
                return true;
            return false;
        }

        public bool AddNewMember(TeamMembers item)
        {
            if (CheckOnlyOnePlayer(item) == true)
                return false;
            Team newMember = _dbContext.Teams.Where(a => a.Id == item.Team.Id)
                                    .Include(a => a.TeamMembers)
                                    .First();
            newMember.TeamMembers.Add(item);
            SaveChanges();
            User newMemberUser = _dbContext.Users.Where(a => a.Id == item.User.Id)
                                       .Include(a => a.TeamMembers)
                                       .First();
            newMemberUser.TeamMembers.Add(item);
            SaveChanges();
            var result = Check(item);
            if (result)
                return true;
            return false;
        }

        public bool Check(TeamMembers item)
        {
            var db = _dbContext.TeamMembers.Where(a => a.User.Id == item.User.Id && a.Team.Id == item.Team.Id)
                            .FirstOrDefault();
            if (db != null)
                return true;
            return false;
        }

        public bool CheckOnlyOnePlayer(TeamMembers item)
        {
            var team = _dbContext.Teams.Where(a => a.Id == item.Team.Id)
                     .FirstOrDefault();
            return team.OnlyOnePlayer;
        }
        public async Task<TeamMembers> GetMyTeams(int gameId, int userId)
        {
            TeamMembers teamMember = await _dbContext.TeamMembers.Where(a => a.Team.Games.Id == gameId && a.User.Id == userId)
                                        .Include(a => a.Team)
                                        .Include(a => a.Team.Games)
                                        .Include(a => a.User)
                                        .FirstOrDefaultAsync();
            return await Task.FromResult<TeamMembers>(teamMember);
        }
        public IEnumerable<TeamMembers> GetTeamMembers(int idTeam)
        {
            IEnumerable<TeamMembers> list = _dbContext.TeamMembers.Where(a => a.Team.Id == idTeam)
                                        .Include(a => a.Team)
                                        .Include(a => a.User)
                                        .ToList();
            return list;
        }
    }
}
