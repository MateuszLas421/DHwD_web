using DHwD_web.Data.Interfaces;
using Models.ModelsDB;
using Models.ModelsMobile;
using System;
using System.Threading.Tasks;

namespace DHwD_web.Operations
{
    public class SolutionsOperations
    {
        public async Task<bool> SaveOnServer(IChatsRepo _chatsRepo, ITeamMembersRepo _teamMembersRepo, string text, int userId, Games game)
        {
            Chats message = new Chats();
            message.Team = (await _teamMembersRepo.GetMyTeams(game.Id, userId)).Team;
            message.Game = game;
            message.IsSystem = true;
            message.Text = text;
            message.DateTimeCreate = DateTime.UtcNow;
            if (await _chatsRepo.SaveOnTheServer(message))
                return await Task.FromResult<bool>(true);
            return await Task.FromResult<bool>(false);
        }

        public async Task<bool> EndPlace(IActivePlacesRepo _activePlacesRepo, ITeamRepo _teamRepo, IStatusRepo _statusRepo, SolutionRequest solutionRequest)
        {
            try
            {
                ActivePlacesOperations activePlacesOperations = new ActivePlacesOperations();
                var Item = await _activePlacesRepo.GetActivePlacebyTeamIDandPlaceID(solutionRequest.Id_Team, solutionRequest.Id_Place);
                Item.IsCompleted = true;
                var result = await _activePlacesRepo.Update(Item);
                if (result != true)
                    return await Task.FromResult<bool>(false);

                Team team = _teamRepo.GetTeamById(solutionRequest.Id_Team);
                var status = _statusRepo.GetStatusById(team.StatusRef);
                ActivePlacesOperations aPOperations = new ActivePlacesOperations();
                if (Item.UnlockedPlace != null && Item.UnlockedPlace != "")
                {
                    var unlockedstatus = await activePlacesOperations.Update_Unblocked_Activ_Place(_activePlacesRepo, Item, solutionRequest.Id_Team);
                    if (unlockedstatus == false)
                        return await Task.FromResult<bool>(false);
                }
                if (Item.Required == true)
                {
                    status = await aPOperations.Update_ActivePlace_in_Status(status, Item.UnlockedPlace);
                    if (!await _statusRepo.Update(status))
                        return await Task.FromResult<bool>(false);
                }
                return await Task.FromResult<bool>(true);
            }
            catch (Exception)
            {
                return await Task.FromResult<bool>(false);
            }
        }
    }
}
