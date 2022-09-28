using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimCom.Core.Constants;
using SimCom.Core.DomainModels.Users;
using SimCom.Data;

namespace SimCom.Web.Extensions
{
    public static class AppBuilderExtensions
    {
        public static void EnsureMigrationOfContext<T>(this IApplicationBuilder app) where T : DbContext
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<T>();
                dbContext.Database.Migrate();
            }
        }
    }
}
