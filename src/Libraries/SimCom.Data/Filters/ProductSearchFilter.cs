using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Data.Filters
{
    public record ProductSearchFilter : PaginationFilter
    {
        public string? Name { get; set; }

        public int? BrandId { get; set; }

        public int? CategoryId { get; set; }

        public string? ProductMainId { get; set; }
    }
}
