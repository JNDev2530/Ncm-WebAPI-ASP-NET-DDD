using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NcmAPI.Domain.Entities;
using NcmAPI.Domain.Interfaces;
using NcmAPI.Infrastructure.Data;

namespace NcmAPI.Infrastructure.Repositories
{
    public class OldNcmRepository
    : GenericRepository<OldNcm>, IOldNcmRepository
    {
        public OldNcmRepository(AppDbContext context) : base(context) { }

        public async Task<OldNcm> GetByCodeAsync(string code)
        {
            return await _context.OldNcms
                              .FirstOrDefaultAsync(o => o.Code.Value == code);
        }
    }

}