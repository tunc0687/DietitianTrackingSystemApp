using DietitianTrackingSystemApp.Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianTrackingSystemApp.Data.Domain.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasIndex(x => new
            {
                x.UserId,
                x.RoleId
            }).IsUnique();

            builder.HasOne(x => x.User).WithMany(x => x.UserRoleUsers).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Role).WithMany(x => x.UserRoles).HasForeignKey(x => x.RoleId);

            builder.Property(x => x.CreatedDate).HasColumnType("datetime");
            builder.Property(x => x.UpdatedDate).HasColumnType("datetime");
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.CreatedByNavigation).WithMany(x => x.UserRoleCreatedByNavigations).HasForeignKey(x => x.CreatedBy);
            builder.HasOne(x => x.UpdatedByNavigation).WithMany(x => x.UserRoleUpdatedByNavigations).HasForeignKey(x => x.UpdatedBy);
        }
    }
}
