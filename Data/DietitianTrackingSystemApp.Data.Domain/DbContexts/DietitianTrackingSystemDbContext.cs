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

        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<ClientChronicDisease> ClientChronicDiseases { get; set; } = null!;
        public virtual DbSet<ClientConsultant> ClientConsultants { get; set; } = null!;
        public virtual DbSet<ClientDietTemplate> ClientDietTemplates { get; set; } = null!;
        public virtual DbSet<DietTemplate> DietTemplates { get; set; } = null!;

        onmo

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<City>(entity =>
        //    {
        //        entity.Property(e => e.Name).HasMaxLength(100);
        //    });

        //    modelBuilder.Entity<County>(entity =>
        //    {
        //        entity.Property(e => e.Name).HasMaxLength(100);

        //        entity.HasOne(d => d.City)
        //            .WithMany(p => p.Counties)
        //            .HasForeignKey(d => d.CityId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Counties_Cities");
        //    });

        //    modelBuilder.Entity<Customer>(entity =>
        //    {
        //        entity.Property(e => e.CompanyName).HasMaxLength(300);

        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.Email).HasMaxLength(100);

        //        entity.Property(e => e.MobilePhone).HasMaxLength(30);

        //        entity.Property(e => e.Name).HasMaxLength(200);

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.CustomerCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Customers_Users");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.CustomerUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_Customers_Users1");
        //    });

        //    modelBuilder.Entity<Document>(entity =>
        //    {
        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.Name).HasMaxLength(100);

        //        entity.Property(e => e.PublicUrl).HasMaxLength(1000);

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.DocumentCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Documents_Users");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.DocumentUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_Documents_Users1");
        //    });

        //    modelBuilder.Entity<ExplorationOperation>(entity =>
        //    {
        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.Latitude).HasMaxLength(20);

        //        entity.Property(e => e.Longitude).HasMaxLength(20);

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.ExplorationOperationCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ExplorationOperations_Users");

        //        entity.HasOne(d => d.Project)
        //            .WithMany(p => p.ExplorationOperations)
        //            .HasForeignKey(d => d.ProjectId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ExplorationOperations_Projects");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.ExplorationOperationUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_ExplorationOperations_Users1");
        //    });

        //    modelBuilder.Entity<ExplorationOperationDocument>(entity =>
        //    {
        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.Description).HasMaxLength(2000);

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.ExplorationOperationDocumentCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ExplorationOperationDocuments_Users");

        //        entity.HasOne(d => d.Document)
        //            .WithMany(p => p.ExplorationOperationDocuments)
        //            .HasForeignKey(d => d.DocumentId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ExplorationOperationDocuments_Documents");

        //        entity.HasOne(d => d.ExplorationOperation)
        //            .WithMany(p => p.ExplorationOperationDocuments)
        //            .HasForeignKey(d => d.ExplorationOperationId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ExplorationOperationDocuments_ExplorationOperations");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.ExplorationOperationDocumentUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_ExplorationOperationDocuments_Users1");
        //    });

        //    modelBuilder.Entity<MessageTemplate>(entity =>
        //    {
        //        entity.Property(e => e.Ccemails)
        //            .HasMaxLength(1000)
        //            .HasColumnName("CCEmails");

        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.Subject).HasMaxLength(300);

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.MessageTemplateCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_MessageTemplates_Users");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.MessageTemplateUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_MessageTemplates_Users1");
        //    });

        //    modelBuilder.Entity<Module>(entity =>
        //    {
        //        entity.Property(e => e.Name).HasMaxLength(500);
        //    });

        //    modelBuilder.Entity<Page>(entity =>
        //    {
        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.Name).HasMaxLength(300);

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.PageCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .HasConstraintName("FK_Pages_Users");

        //        entity.HasOne(d => d.Module)
        //            .WithMany(p => p.Pages)
        //            .HasForeignKey(d => d.ModuleId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Pages_Modules");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.PageUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_Pages_Users1");
        //    });

        //    modelBuilder.Entity<Project>(entity =>
        //    {
        //        entity.Property(e => e.Address).HasMaxLength(1000);

        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.OfficePhone).HasMaxLength(30);

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.AssignedUser)
        //            .WithMany(p => p.ProjectAssignedUsers)
        //            .HasForeignKey(d => d.AssignedUserId)
        //            .HasConstraintName("FK_Projects_Users");

        //        entity.HasOne(d => d.City)
        //            .WithMany(p => p.Projects)
        //            .HasForeignKey(d => d.CityId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Projects_Cities");

        //        entity.HasOne(d => d.County)
        //            .WithMany(p => p.Projects)
        //            .HasForeignKey(d => d.CountyId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Projects_Counties");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.ProjectCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Projects_Users1");

        //        entity.HasOne(d => d.Customer)
        //            .WithMany(p => p.Projects)
        //            .HasForeignKey(d => d.CustomerId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Projects_Customers");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.ProjectUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_Projects_Users2");
        //    });

        //    modelBuilder.Entity<ProjectComment>(entity =>
        //    {
        //        entity.Property(e => e.Comment).HasMaxLength(2000);

        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.ProjectCommentCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProjectComments_Users");

        //        entity.HasOne(d => d.Project)
        //            .WithMany(p => p.ProjectComments)
        //            .HasForeignKey(d => d.ProjectId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProjectComments_Projects");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.ProjectCommentUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_ProjectComments_Users1");
        //    });

        //    modelBuilder.Entity<ProjectHistory>(entity =>
        //    {
        //        entity.HasOne(d => d.AssignedUser)
        //            .WithMany(p => p.ProjectHistories)
        //            .HasForeignKey(d => d.AssignedUserId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProjectHistories_Users");

        //        entity.HasOne(d => d.Project)
        //            .WithMany(p => p.ProjectHistories)
        //            .HasForeignKey(d => d.ProjectId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProjectHistories_Projects");
        //    });

        //    modelBuilder.Entity<ProjectQuestionAnswer>(entity =>
        //    {
        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.Text).HasMaxLength(2000);

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.ProjectQuestionAnswerCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProjectQuestionAnswers_Users");

        //        entity.HasOne(d => d.Project)
        //            .WithMany(p => p.ProjectQuestionAnswers)
        //            .HasForeignKey(d => d.ProjectId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProjectQuestionAnswers_Projects");

        //        entity.HasOne(d => d.Question)
        //            .WithMany(p => p.ProjectQuestionAnswers)
        //            .HasForeignKey(d => d.QuestionId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProjectQuestionAnswers_Questions");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.ProjectQuestionAnswerUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_ProjectQuestionAnswers_Users1");
        //    });

        //    modelBuilder.Entity<ProjectStatusQuestion>(entity =>
        //    {
        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.ProjectStatusQuestionCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProjectStatusQuestions_Users");

        //        entity.HasOne(d => d.Question)
        //            .WithMany(p => p.ProjectStatusQuestions)
        //            .HasForeignKey(d => d.QuestionId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_ProjectStatusQuestions_Questions");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.ProjectStatusQuestionUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_ProjectStatusQuestions_Users1");
        //    });

        //    modelBuilder.Entity<Question>(entity =>
        //    {
        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.Text).HasMaxLength(1000);

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.QuestionCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Questions_Users");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.QuestionUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_Questions_Users1");
        //    });

        //    modelBuilder.Entity<QuestionAnswerOption>(entity =>
        //    {
        //        entity.Property(e => e.AnswerOptionText).HasMaxLength(300);

        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.QuestionAnswerOptionCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_QuestionAnswerOptions_Users");

        //        entity.HasOne(d => d.Question)
        //            .WithMany(p => p.QuestionAnswerOptions)
        //            .HasForeignKey(d => d.QuestionId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_QuestionAnswerOptions_Questions");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.QuestionAnswerOptionUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_QuestionAnswerOptions_Users1");
        //    });

        //    modelBuilder.Entity<Role>(entity =>
        //    {
        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.Name).HasMaxLength(200);

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.RoleCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .HasConstraintName("FK_Roles_Users");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.RoleUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_Roles_Users1");
        //    });

        //    modelBuilder.Entity<RolePage>(entity =>
        //    {
        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.RolePageCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .HasConstraintName("FK_RolePages_Users");

        //        entity.HasOne(d => d.Page)
        //            .WithMany(p => p.RolePages)
        //            .HasForeignKey(d => d.PageId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_RolePages_Pages");

        //        entity.HasOne(d => d.Role)
        //            .WithMany(p => p.RolePages)
        //            .HasForeignKey(d => d.RoleId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_RolePages_Roles");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.RolePageUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_RolePages_Users1");
        //    });

        //    modelBuilder.Entity<User>(entity =>
        //    {
        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.Email).HasMaxLength(300);

        //        entity.Property(e => e.Name).HasMaxLength(300);

        //        entity.Property(e => e.Password).HasMaxLength(1000);

        //        entity.Property(e => e.Surname).HasMaxLength(300);

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.InverseCreatedByNavigation)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .HasConstraintName("FK_Users_Users");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.InverseUpdatedByNavigation)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_Users_Users1");
        //    });

        //    modelBuilder.Entity<UserRole>(entity =>
        //    {
        //        entity.Property(e => e.CreatedDate).HasColumnType("datetime");

        //        entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

        //        entity.HasOne(d => d.CreatedByNavigation)
        //            .WithMany(p => p.UserRoleCreatedByNavigations)
        //            .HasForeignKey(d => d.CreatedBy)
        //            .HasConstraintName("FK_UserRoles_Users1");

        //        entity.HasOne(d => d.Role)
        //            .WithMany(p => p.UserRoles)
        //            .HasForeignKey(d => d.RoleId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_UserRoles_Roles");

        //        entity.HasOne(d => d.UpdatedByNavigation)
        //            .WithMany(p => p.UserRoleUpdatedByNavigations)
        //            .HasForeignKey(d => d.UpdatedBy)
        //            .HasConstraintName("FK_UserRoles_Users2");

        //        entity.HasOne(d => d.User)
        //            .WithMany(p => p.UserRoleUsers)
        //            .HasForeignKey(d => d.UserId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_UserRoles_Users");
        //    });
        //}
    }
}