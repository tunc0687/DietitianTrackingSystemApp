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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(50).IsRequired();
            builder.Property(x => x.MobilePhone).HasMaxLength(20).IsRequired();

            builder.Property(x => x.DateOfBirth).HasColumnType("datetime");
            builder.Property(x => x.StartingDate).HasColumnType("datetime");

            builder.Property(x => x.CreatedDate).HasColumnType("datetime");
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.UpdatedDate).HasColumnType("datetime");

            builder.HasOne(x => x.CreatedByNavigation).WithMany(x => x.InverseCreatedByNavigation).HasForeignKey(x => x.CreatedBy);
            builder.HasOne(x => x.UpdatedByNavigation).WithMany(x => x.InverseUpdatedByNavigation).HasForeignKey(x => x.UpdatedBy);


        }
    }
}
