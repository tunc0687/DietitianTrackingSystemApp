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
    public class DietTemplateConfiguration : IEntityTypeConfiguration<DietTemplate>
    {
        public void Configure(EntityTypeBuilder<DietTemplate> builder)
        {
            builder.Property(x =>x.DietName).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Definition).HasColumnType("nText").IsRequired();
        }
    }
}
