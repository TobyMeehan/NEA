using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public interface IConversationRepository
    {
        Task<Conversation> AddAsync(string name, string groupId);

        Task<Conversation> GetByIdAsync(string name);

        Task<IEnumerable<Conversation>> GetByUserAsync(string userId);

        Task<Conversation> UpdateAsync(Conversation conversation);

        Task DeleteAsync(string id);


        Task AddUserAsync(string conversationId, string userId, string displayName);

        Task RemoveUserAsync(string conversationId, string userId);
    }
}
