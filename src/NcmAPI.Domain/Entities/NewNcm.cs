using NcmAPI.Domain.Exceptions;
using NcmAPI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NcmAPI.Domain.Entities
{
    public class NewNcm
    {
       
        public int Id { get; set; }
     
        public NcmCode Code { get; private set; }

        public int OldId { get; private set; }
        public OldNcm OldNcm { get; private set; }

        protected NewNcm() { }
        public NewNcm(NcmCode code, OldNcm oldNcm) 
        {
            Code = code;
            OldNcm = oldNcm ?? throw new DomainException("Codigo do Ncm Antigo não pode ser nulo!");
            OldId = oldNcm.Id;
        }
    }
}
