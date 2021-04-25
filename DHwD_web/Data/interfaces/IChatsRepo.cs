using Models.ModelsDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface IChatsRepo : Base.IBaseRepo
    {
        Task<bool> SaveOnTheServer(Chats message);

        Task<IEnumerable<Chats>> GetChat(int gameid, int userId);
    }
}
