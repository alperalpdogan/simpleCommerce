using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimCom.Core.DomainModels.Users;

namespace SimCom.Data.Configurations.IdentityConfigurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> b)
        {
            //rest of the identity tables are left untouched
            //as this is just an exercise
            b.ToTable("Users");
        }
    }
}