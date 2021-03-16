using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public interface IGroupRepository
    {
        Task<Group> AddAsync(string name);

        Task<Group> GetByIdAsync(string id);

        Task<IEnumerable<Group>> GetByUserAsync(string userId);

        Task<Group> UpdateAsync(Group group);

        Task DeleteAsync(string id);


        Task AddUserAsync(string groupId, string userId, string displayName);

        Task RemoveUserAsync(string groupId, string userId);


        Task AddConversationAsync(string groupId, string conversationId);

        Task RemoveConversationAsync(string groupId, string conversationId);
    }
}