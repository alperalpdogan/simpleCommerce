using SimCom.Core.DomainModels;
using SimCom.Core.Paging;
using SimCom.Data.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Services.Catalog
{
    public interface IProductService
    {
        Task<IList<Product>> GetMainPageProductsAsync();

        Task<IList<Product>> GetProductsByMainIdAsync(string productMainId);

        Task<Product> GetProductByGtinAsync(string gtin);

        Task<IPagedList<Product>> FilterProductsAsync(ProductSearchFilter filter);
    }
}
