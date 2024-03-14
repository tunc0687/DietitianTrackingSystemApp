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
    public class ClientChronicDiseaseConfiguration : IEntityTypeConfiguration<ClientChronicDisease>
    {
        public void Configure(EntityTypeBuilder<ClientChronicDisease> builder)
        {
            //builder.Property(x => x.Diabetes).HasDefaultValue(false).IsRequired();
            //builder.Property(x => x.HighCholesterol).HasDefaultValue(false).IsRequired();
            //builder.Property(x => x.HeartRhythmDisorder).HasDefaultValue(false).IsRequired();
            //builder.Property(x => x.Atherosclerosis).HasDefaultValue(false).IsRequired();
            //builder.Property(x => x.BloodPressure).HasDefaultValue(false).IsRequired();
            builder.HasIndex(x => x.ClientUserId).IsUnique();
            builder.HasOne(x => x.ClientUser).WithMany(x => x.ClientChronicDiseases).HasForeignKey(x => x.ClientUserId);
        }
    }
}
