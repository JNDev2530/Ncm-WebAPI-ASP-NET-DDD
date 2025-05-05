using NcmAPI.Domain.Entities;
using NcmAPI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcmAPI.Domain.Interfaces
{
    public interface IOldNcmRepository : IGenericRepository<OldNcm>
    {
        Task<OldNcm> GetByCodeAsync(string code);
        
    }
}
