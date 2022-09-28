using SimCom.Core.DomainModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Core.DomainModels
{
    public record ProductPicture : BaseEntity
    {
        public string Url { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int DisplayOrder { get; set; }
    }
}
