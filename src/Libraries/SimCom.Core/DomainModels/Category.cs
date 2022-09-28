using SimCom.Core.DomainModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Core.DomainModels
{
    public record Category : SoftDeletedEntity
    {
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category>? SubCategories { get; set; }

        public virtual ICollection<CategoryAttribute>? CategoryAttributes { get; set; }

    }
}
