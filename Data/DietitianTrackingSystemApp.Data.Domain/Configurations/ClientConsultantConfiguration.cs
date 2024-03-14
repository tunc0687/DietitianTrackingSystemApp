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
    public class ClientConsultantConfiguration : IEntityTypeConfiguration<ClientConsultant>
    {
        public void Configure(EntityTypeBuilder<ClientConsultant> builder)
        {
            builder.HasIndex(x => new
            {
                x.ClientUserId,
                x.ConsultantUserId
            }).IsUnique();

            builder.HasOne(x => x.ClientUser).WithMany(x => x.ClientUsers).HasForeignKey(x => x.ClientUserId);
            builder.HasOne(x => x.ConsultantUser).WithMany(x => x.ConsultantUsers).HasForeignKey(x => x.ConsultantUserId);
        }
    }
}
