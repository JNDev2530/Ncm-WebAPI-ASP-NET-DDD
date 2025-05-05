using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NcmAPI.Domain.Exceptions;

namespace NcmAPI.Domain.ValueObjects
{
    [Owned]
    public sealed class NcmCode
    {
        
        public string Value { get;  }
    
        protected NcmCode() { }

        public NcmCode(string value)
        {
            if (!string.IsNullOrWhiteSpace(Value))
            {
                throw new DomainException("Codigo do NCM não pode ser vazio!");
            }

            if (!Regex.IsMatch(value, @"^\d{8}$"))
                throw new DomainException("Código NCM deve ter 8 dígitos numéricos.");

            Value = value;
        }
    }
}
