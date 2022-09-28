using SimCom.Core.DomainModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Core.DomainModels
{
    public record Product : SoftDeletedEntity
    {
        public string Name { get; set; }

        public string Gtin { get; set; }

        public string Description { get; set; }

        public string ProductMainId { get; set; }

        public string ShortDescription { get; set; }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }

        public Guid ProductIdentifier { get; set; }

        public bool DisplayedOnMainPage { get; set; }

        public decimal SalePrice { get; set; }

        public decimal? ListPrice { get; set; }

        public virtual ICollection<ProductAttributeValueCombination>? ProductAttributeValueCombinations { get; set; }

        public virtual ICollection<ProductPicture>? Pictures { get; set; }
    }
}
