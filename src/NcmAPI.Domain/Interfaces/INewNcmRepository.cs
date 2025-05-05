using NcmAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcmAPI.Domain.Interfaces
{
    public interface INewNcmRepository
    {
        Task<IEnumerable<NewNcm>> GetByOldIdAsync(int oldId);
    }
}
