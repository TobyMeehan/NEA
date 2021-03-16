using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core
{
    public interface IUserRepository
    {
        Task<User> AddAsync(string username, string password, string description);

        Task<User> GetByIdAsync(string id);

        Task<User> GetByUsernameAsync(string username);

        Task<User> UpdateAsync(User user);

        Task DeleteAsync(string id);
    }
}
