using DietitianTrackingSystemApp.Data.Domain.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DietitianTrackingSystemApp.Data.Domain.Entities
{
    public partial class DietitianTrackingSystemDbContext : DbContext
    {
        public DietitianTrackingSystemDbContext()
        {
        }

        public DietitianTrackingSystemDbContext(DbContextOptions<DietitianTrackingSystemDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientChronicDiseaseConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConsultantConfiguration());
            modelBuilder.ApplyConfiguration(new ClientDietTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new DietTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }

        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<ClientChronicDisease> ClientChronicDiseases { get; set; } = null!;
        public virtual DbSet<ClientConsultant> ClientConsultants { get; set; } = null!;
        public virtual DbSet<ClientDietTemplate> ClientDietTemplates { get; set; } = null!;
        public virtual DbSet<DietTemplate> DietTemplates { get; set; } = null!;
    }
}