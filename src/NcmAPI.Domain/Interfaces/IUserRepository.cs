using NcmAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcmAPI.Domain.Interfaces
{
    public interface IUserRepository  
    {
        Task<User?> GetByUsernameAsync(string username);
        Task AddAsync(User user);

    }
}
