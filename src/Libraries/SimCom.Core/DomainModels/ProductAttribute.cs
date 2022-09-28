using SimCom.Core.DomainModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Core.DomainModels
{
    public record ProductAttribute : BaseEntity
    {
        public string AttributeName { get; set; }
    }
}
