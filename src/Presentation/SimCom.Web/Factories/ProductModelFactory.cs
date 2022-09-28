using SimCom.Core.Paging;
using SimCom.Data.Filters;
using SimCom.Services.Catalog;
using SimCom.Web.Models;

namespace SimCom.Web.Factories
{
    public class ProductModelFactory : IProductModelFactory
    {
        private readonly IProductService _productService;

        public ProductModelFactory(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IList<ProductSummaryModel>> GetMainPageProductsAsync()
        {
            var products = await _productService.GetMainPageProductsAsync();

            var productModels = new List<ProductSummaryModel>();
            foreach (var product in products)
            {
                productModels.Add(new ProductSummaryModel()
                {
                    ListPrice = product.ListPrice,
                    SalePrice = product.SalePrice,
                    MainPicture = new ProductPictureModel()
                    {
                        Url = product.Pictures.OrderBy(pic => pic.DisplayOrder).FirstOrDefault().Url
                    },
                    Name = product.Name,
                    ProductIdentifier = product.ProductIdentifier
                });
            }

            return productModels;
        }
    }
}
