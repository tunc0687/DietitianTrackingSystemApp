using System;
using System.Collections.Generic;

namespace DietitianTrackingSystemApp.Data.Domain.Entities
{
    public partial class UserRole : BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
        public virtual User? UpdatedByNavigation { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
