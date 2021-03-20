using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Core.Security
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);

        bool VerifyPassword(string providedPassword, string hashedPassword);
    }
}
