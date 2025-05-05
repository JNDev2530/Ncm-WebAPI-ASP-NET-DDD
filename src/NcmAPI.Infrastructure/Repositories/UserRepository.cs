using Microsoft.EntityFrameworkCore;
using NcmAPI.Domain.Entities;
using NcmAPI.Domain.Interfaces;
using NcmAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcmAPI.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext Context) : base(Context)
        {
        }


        public async Task<User?> GetByUsernameAsync(string username) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

        public async Task AddAsync(User user) =>
            await _context.Users.AddAsync(user);


    }
}
