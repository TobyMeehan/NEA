using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public interface IMessageRepository
    {
        Task<Message> AddAsync(string userId, string body);

        Task<Message> GetByIdAsync(string id);

        Task<IEnumerable<Message>> GetByConversationAsync(string conversationId);

        Task<Message> UpdateAsync(Message message);

        Task DeleteAsync(string id);
    }
}
