using SimCom.Data.Repository;
using SimCom.Services.Catalog;
using SimCom.Services.DummyDataService;
using SimCom.Web.Factories;

namespace SimCom.Web.Extensions
{
    public static class DependencyRegistrar
    {
        public static void RegisterGenericRepository(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        }

        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<DumyDataCreator, DumyDataCreator>();
            builder.Services.AddScoped<DummyUserCreator, DummyUserCreator>();
        }

        public static void RegisterFactories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProductModelFactory, ProductModelFactory>();
        }
    }
}
