using NcmAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcmAPI.Application.Interfaces
{
    public interface INcmQueryService
    {
        Task<IEnumerable<NewNcmDto>> GetNewNcmsByOldCodeAsync(string oldCode);
        Task CreateNewNcmAsync(int oldId, string newCode);
    }
}
