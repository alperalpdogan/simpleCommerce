using Microsoft.EntityFrameworkCore;
using SimCom.Core.DomainModels.Users;
using SimCom.Data;

namespace SimCom.Web.Extensions
{
    public static class WebBuilderExtensions
    {
        public static void SetUpDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<SimComDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("SimCom")));

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<Role>()
                .AddEntityFrameworkStores<SimComDbContext>();
        }
    }
}
