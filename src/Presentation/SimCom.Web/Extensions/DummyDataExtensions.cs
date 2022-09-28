using SimCom.Services.DummyDataService;

namespace SimCom.Web.Extensions
{
    public static class DummyDataExtensions
    {
        public static async Task CreateProductDummyData(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;

            using (var scope = serviceProvider.CreateScope())
            {
                var dumyDataCreator = scope.ServiceProvider.GetRequiredService<DumyDataCreator>();

                await dumyDataCreator.PopulateProductTablesWithDummyDataAsync();
            }
        }

        public static async Task CreateDummyUsers(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices;

            using (var scope = serviceProvider.CreateScope())
            {
                var dumyDataCreator = scope.ServiceProvider.GetRequiredService<DummyUserCreator>();

                await dumyDataCreator.CreateDummyUsersForEachRole();
            }
        }
    }
}
