using SimCom.Core.Paging;
using SimCom.Web.Models;

namespace SimCom.Web.Factories
{
    public interface IProductModelFactory
    {
        Task<IList<ProductSummaryModel>> GetMainPageProductsAsync();
    }
}