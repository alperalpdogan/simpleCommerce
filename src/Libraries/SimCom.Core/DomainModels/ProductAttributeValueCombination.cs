using SimCom.Core.DomainModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Core.DomainModels
{
    public record class ProductAttributeValueCombination : BaseEntity
    {
        public virtual Product Product { get; set; }

        public int ProductId { get; set; }

        public virtual AttributeValue AttributeValue { get; set; }

        public int AttributeValueId { get; set; }

        public virtual ProductAttribute ProductAttribute { get; set; }

        public int ProductAttributeId { get; set; }

    }
}
