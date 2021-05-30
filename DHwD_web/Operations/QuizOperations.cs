using DHwD_web.Data.Interfaces;
using Models.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHwD_web.Operations
{
    public class QuizOperations
    {
        public async Task<List<Chats>> GetMessageAsync(IQuizRepo _repository, IActivePlacesRepo _activePlacesRepo, int number, ActivePlace activeplace, Team team, Games game)
        {
            List<Chats> chats = new List<Chats>();
            bool next = true;
            while (next)
            {
                var quiz = await _repository.GetQuizbyIdPlace_Id_Sequence(activeplace.Place.Id, number);
                if (quiz == null)
                    break;
                if (!String.IsNullOrEmpty(quiz.Message_1))
                {
                    chats.Add(new Chats
                    {
                        Team = team,
                        Text = quiz.Message_1,
                        DateTimeCreate = DateTime.UtcNow,
                        IsSystem = true,
                        Game = game
                    });
                }
                if (!String.IsNullOrEmpty(quiz.Message_2))
                {
                    chats.Add(new Chats
                    {
                        Team = team,
                        Text = quiz.Message_2,
                        DateTimeCreate = DateTime.UtcNow,
                        IsSystem = true,
                        Game = game
                    });
                }
                if (!String.IsNullOrEmpty(quiz.Message_3))
                {
                    chats.Add(new Chats
                    {
                        Team = team,
                        Text = quiz.Message_3,
                        DateTimeCreate = DateTime.UtcNow,
                        IsSystem = true,
                        Game = game
                    });
                }
                if (!String.IsNullOrEmpty(quiz.Questions))
                {
                    chats.Add(new Chats
                    {
                        Team = team,
                        Text = quiz.Questions,
                        DateTimeCreate = DateTime.UtcNow,
                        IsSystem = true,
                        Game = game
                    });
                    next = false;
                }
                else
                {
                    number++;
                    next = true;
                }
            }
            var item = await _repository.GetQuizbyIdPlace_Id_Sequence(activeplace.Place.Id, number);
            if (item != null)
            {
                activeplace.QuizStatus = item.Id.ToString();
                await _activePlacesRepo.Update(activeplace);
            }
            return await Task.FromResult(chats);
        }
    }
}
