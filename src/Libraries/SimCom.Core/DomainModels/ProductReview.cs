using SimCom.Core.DomainModels.Common;
using SimCom.Core.DomainModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Core.DomainModels
{
    public record ProductReview : BaseEntity
    {
        public string Review { get; set; }

        public int Starts { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
