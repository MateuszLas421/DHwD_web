using DHwD_web.Data.Interfaces;
using DHwD_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Operations
{
    public class SolutionsOperations
    {
        public async Task<bool> SaveOnServer(IChatsRepo _chatsRepo,ITeamMembersRepo _teamMembersRepo , string text, int userId, Games game)
        {
            Chats message = new Chats();
            message.Team = (await _teamMembersRepo.GetMyTeams(game.Id, userId)).Team;
            message.Game = game;
            message.IsSystem = true;
            message.Text = text;
            message.DateTimeCreate = DateTime.UtcNow;
            if(await _chatsRepo.SaveOnTheServer(message))
                return await Task.FromResult<bool>(true);
            return await Task.FromResult<bool>(false);
        }
    }
}
