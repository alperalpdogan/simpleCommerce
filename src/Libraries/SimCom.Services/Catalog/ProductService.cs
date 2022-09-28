using Microsoft.EntityFrameworkCore;
using SimCom.Core.DomainModels;
using SimCom.Core.Paging;
using SimCom.Data.Extensions;
using SimCom.Data.Filters;
using SimCom.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Services.Catalog
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> GetProductByGtinAsync(string gtin)
        {
            if (string.IsNullOrWhiteSpace(gtin))
                throw new ArgumentNullException(nameof(gtin));

            return await _productRepository.TableAsNoTracking
                .Where(p => p.Gtin == gtin)
                .SingleOrDefaultAsync();
        }

        public async Task<IPagedList<Product>> FilterProductsAsync(ProductSearchFilter filter)
        {
            var products = _productRepository.TableAsNoTracking;

            if (filter.BrandId != null)
                products = products.Where(p => p.BrandId == filter.BrandId);

            if (!string.IsNullOrWhiteSpace(filter.Name))
                products = products.Where(p => p.Name.Contains(filter.Name));

            if (!string.IsNullOrWhiteSpace(filter.ProductMainId))
                products = products.Where(p => p.ProductMainId == filter.ProductMainId);

            products = products
                .Include(p => p.Pictures)
                .GroupBy(p => p.ProductMainId)
                .Select(g => g.First());

            return await products.ToPagedListAsync(filter);
        }

        public async Task<IList<Product>> GetProductsByMainIdAsync(string productMainId)
        {
            if (string.IsNullOrWhiteSpace(productMainId))
                throw new ArgumentNullException(nameof(productMainId));

            return await _productRepository.TableAsNoTracking
                .Where(p => p.ProductMainId == productMainId)
                .Include(p => p.Pictures)
                .Include(o => o.Brand)
                .ToListAsync();
        }

        public async Task<IList<Product>> GetMainPageProductsAsync()
        {
            return await _productRepository
                .TableAsNoTracking
                .Where(p => p.DisplayedOnMainPage)
                .Include(p => p.Pictures)
                .ToListAsync();
        }
    }
}
