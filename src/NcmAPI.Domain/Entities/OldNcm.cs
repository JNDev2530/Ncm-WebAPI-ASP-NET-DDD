using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NcmAPI.Domain.ValueObjects;

namespace NcmAPI.Domain.Entities
{
    public class OldNcm
    {
       
        public int Id { get; set; }
      
        public NcmCode Code { get; set; }

        private readonly List<NewNcm> _newNcms = new();
        public IReadOnlyCollection<NewNcm> NewNcms => _newNcms.AsReadOnly();

        protected OldNcm() { }

        public OldNcm(NcmCode code)
        {
            Code = code;
        }

        // Método de domínio para associar um NewNcm
        public void AddNewNcm(NewNcm child)
        {
            if (child == null)
                throw new ArgumentNullException(nameof(child));

            if (child.OldNcm != this)
                throw new InvalidOperationException("NewNcm pertence a outro OldNcm.");

            _newNcms.Add(child);
        }

        public NewNcm CreateNew(NcmCode newCode)
        {
            var child = new NewNcm(newCode, this);
            _newNcms.Add(child);
            return child;
        }

    }
}
