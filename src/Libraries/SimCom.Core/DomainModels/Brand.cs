using SimCom.Core.DomainModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Core.DomainModels
{
    public record Brand : SoftDeletedEntity
    {
        public string Name { get; set; }
    }
}
