using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Configuration
{
    //public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    //{
    //    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    //    {
    //        builder.HasData(
    //   new IdentityRole
    //   {
    //       Name = "Manager",
    //       NormalizedName = "MANAGER"
    //   },
    //   new IdentityRole
    //   {
    //       Name = "Administrator",
    //       NormalizedName = "ADMINISTRATOR"
    //   }
    //       );
    //    }
    //}



    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "1a2b3c4d-0001-0001-0001-000000000001",
                    Name = "Manager",
                    NormalizedName = "MANAGER",
                    ConcurrencyStamp = "1a2b3c4d-0001"
                },
                new IdentityRole
                {
                    Id = "1a2b3c4d-0002-0002-0002-000000000002",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    ConcurrencyStamp = "1a2b3c4d-0002"
                }
            );
        }
    }

}
