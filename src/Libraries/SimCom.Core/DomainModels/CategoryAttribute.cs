using SimCom.Core.DomainModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Core.DomainModels
{
    public record CategoryAttribute : BaseEntity
    {

        public int DisplayOrder { get; set; }

        public int ProductAttributeId { get; set; }

        public virtual ProductAttribute ProductAttribute { get; set; }
    }
}
