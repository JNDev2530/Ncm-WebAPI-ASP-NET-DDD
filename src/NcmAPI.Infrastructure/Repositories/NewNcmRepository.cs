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
    public class NewNcmRepository : GenericRepository<NewNcm>, INewNcmRepository
    {

        public NewNcmRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<NewNcm>> GetByOldIdAsync(int oldId) =>
        await _context.NewNcms.Where(n => n.OldId == oldId).ToListAsync();
    }
}
