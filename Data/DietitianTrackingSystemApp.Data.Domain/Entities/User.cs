using System;
using System.Collections.Generic;

namespace DietitianTrackingSystemApp.Data.Domain.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            RoleCreatedByNavigations = new HashSet<Role>();
            RoleUpdatedByNavigations = new HashSet<Role>();
            UserRoleCreatedByNavigations = new HashSet<UserRole>();
            UserRoleUpdatedByNavigations = new HashSet<UserRole>();
            UserRoleUsers = new HashSet<UserRole>();
            ClientUsers = new HashSet<ClientConsultant>();
            ConsultantUsers = new HashSet<ClientConsultant>();
            ClientDietTemplates = new HashSet<ClientDietTemplate>();
            ClientChronicDiseases = new HashSet<ClientChronicDisease>();
        }

        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string MobilePhone { get; set; } = null!;
        public byte Status { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
        public virtual User? UpdatedByNavigation { get; set; }
        public virtual ICollection<Role> RoleCreatedByNavigations { get; set; }
        public virtual ICollection<Role> RoleUpdatedByNavigations { get; set; }
        public virtual ICollection<UserRole> UserRoleCreatedByNavigations { get; set; }
        public virtual ICollection<UserRole> UserRoleUpdatedByNavigations { get; set; }
        public virtual ICollection<UserRole> UserRoleUsers { get; set; }
        public virtual ICollection<ClientConsultant> ClientUsers { get; set; }
        public virtual ICollection<ClientConsultant> ConsultantUsers { get; set; }
        public virtual ICollection<ClientDietTemplate> ClientDietTemplates { get; set; }
        public virtual ICollection<ClientChronicDisease> ClientChronicDiseases { get; set; }
    }
}
