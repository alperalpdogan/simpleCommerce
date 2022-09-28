using SimCom.Core.DomainModels;
using SimCom.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCom.Services.DummyDataService
{
    public class DumyDataCreator
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Brand> _brandRepository;

        public DumyDataCreator(IRepository<Product> productRepository,
                               IRepository<Brand> brandRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }

        public async Task PopulateProductTablesWithDummyDataAsync()
        {
            var dataExists = _productRepository.TableAsNoTracking.Any();

            if (dataExists)
                return;

            var nikeBrandId = await _brandRepository.InsertAsync(new Brand() { Name = "Nike" });
            await _productRepository.InsertAsync(new List<Product>
            {
                new Product
                {
                    BrandId = nikeBrandId,
                    Description = "Product description for first one",
                    ShortDescription = "Short product description",
                    Gtin = "123456W",
                    ListPrice = 100,
                    SalePrice = 80,
                    Quantity = 13,
                    Unit = "Pair",
                    Name = "Nike Air Force 1",
                    DisplayedOnMainPage = true,
                    Pictures = new List<ProductPicture>
                    {
                        new ProductPicture()
                        {
                            Url = "https://static.nike.com/a/images/t_default/l3w4varugbogihcpj40e/air-force-1-shadow-ayakkab%C4%B1s%C4%B1-lW4FDD.png",
                            DisplayOrder = 1
                        }
                    },
                    ProductIdentifier = Guid.NewGuid(),
                    ProductMainId = "NAF1",
                    ProductAttributeValueCombinations = new List<ProductAttributeValueCombination>
                    {
                        new ProductAttributeValueCombination()
                        {
                            AttributeValue = new AttributeValue()
                            {
                                Value = "45"
                            },
                            ProductAttribute = new ProductAttribute()
                            {
                                AttributeName = "Size"
                            }
                        },
                        new ProductAttributeValueCombination()
                        {
                            AttributeValue = new AttributeValue()
                            {
                                Value = "White"
                            },
                            ProductAttribute = new ProductAttribute()
                            {
                                AttributeName = "Color"
                            }
                        }
                    }
                },
                new Product()
                {
                    BrandId = nikeBrandId,
                    Description = "Product description for second one",
                    ShortDescription = "Short product description",
                    Gtin = "123456B",
                    SalePrice = 110,
                    Quantity = 7,
                    Unit = "Pair",
                    Name = "Nike Air Force 1",
                    Pictures = new List<ProductPicture>
                    {
                        new ProductPicture()
                        {
                            Url = "https://static.nike.com/a/images/t_default/l3w4varugbogihcpj40e/air-force-1-shadow-ayakkab%C4%B1s%C4%B1-lW4FDD.png",
                            DisplayOrder = 1
                        }
                    },
                    ProductIdentifier = Guid.NewGuid(),
                    ProductMainId = "NAF1",
                    ProductAttributeValueCombinations = new List<ProductAttributeValueCombination>
                    {
                        new ProductAttributeValueCombination()
                        {
                            AttributeValue = new AttributeValue()
                            {
                                Value = "45"
                            },
                            ProductAttribute = new ProductAttribute()
                            {
                                AttributeName = "Size"
                            }
                        },
                        new ProductAttributeValueCombination()
                        {
                            AttributeValue = new AttributeValue()
                            {
                                Value = "Black"
                            },
                            ProductAttribute = new ProductAttribute()
                            {
                                AttributeName = "Color"
                            }
                        }
                    }
                }
            });
        }
    };
}
