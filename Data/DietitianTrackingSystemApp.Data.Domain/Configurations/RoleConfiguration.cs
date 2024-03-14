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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.Property(x => x.CreatedDate).HasColumnType("datetime");
            builder.Property(x => x.UpdatedDate).HasColumnType("datetime");
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.CreatedByNavigation).WithMany(x => x.RoleCreatedByNavigations).HasForeignKey(x => x.CreatedBy);
            builder.HasOne(x => x.UpdatedByNavigation).WithMany(x => x.RoleUpdatedByNavigations).HasForeignKey(x => x.UpdatedBy);
        }
    }
}
