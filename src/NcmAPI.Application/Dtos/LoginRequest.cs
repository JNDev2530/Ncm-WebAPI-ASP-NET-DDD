using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcmAPI.Application.Dtos
{
    public record LoginRequest(string Username, string Password);
}
