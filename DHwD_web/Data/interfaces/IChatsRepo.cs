using Models.ModelsDB;
using Models.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DHwD_web.Data.Interfaces
{
    public interface IChatsRepo : Base.IBaseRepo
    {
        Task<bool> SaveOnTheServer(Chats message);

        Task<bool> SaveListOnTheServer(List<Chats> messages);

        Task<IEnumerable<Chats>> GetChat(int gameid, int userId);

        Task<IEnumerable<Chats>> GetUpdateChat(GetUpdateChatRequest getUpdateChatRequest);
    }
}
