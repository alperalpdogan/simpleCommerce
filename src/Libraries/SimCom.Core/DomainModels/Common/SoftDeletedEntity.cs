using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Core.DomainModels.Common
{
    public record SoftDeletedEntity : BaseEntity
    {
        public bool Deleted { get; set; }

        public DateTime? DeletedOnUtc { get; set; }
    }
}
