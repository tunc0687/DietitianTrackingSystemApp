using DietitianTrackingSystemApp.Data.Domain.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<ClientChronicDisease> ClientChronicDiseases { get; set; } = null!;
        public virtual DbSet<ClientConsultant> ClientConsultants { get; set; } = null!;
        public virtual DbSet<ClientDietTemplate> ClientDietTemplates { get; set; } = null!;
        public virtual DbSet<DietTemplate> DietTemplates { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}