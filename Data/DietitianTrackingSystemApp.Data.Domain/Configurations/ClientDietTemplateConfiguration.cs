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
    public class ClientDietTemplateConfiguration : IEntityTypeConfiguration<ClientDietTemplate>
    {
        public void Configure(EntityTypeBuilder<ClientDietTemplate> builder)
        {
            builder.HasIndex(x => new
            {
                x.ClientUserId,
                x.DietTemplateId
            }).IsUnique();

            builder.Property(x => x.StartingDate).HasColumnType("datetime");
            builder.Property(x => x.EndingDate).HasColumnType("datetime");

            builder.HasOne(x => x.ClientUser).WithMany(x => x.ClientDietTemplates).HasForeignKey(x => x.ClientUserId);
            builder.HasOne(x => x.DietTemplate).WithMany(x => x.ClientDietTemplates).HasForeignKey(x => x.DietTemplateId);
        }
    }
}
