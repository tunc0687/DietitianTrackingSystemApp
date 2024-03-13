﻿using System;
using System.Collections.Generic;

namespace DietitianTrackingSystemApp.Data.Domain.Entities
{
    public partial class Role : BaseEntity
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public string Name { get; set; } = null!;
        public byte Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
        public virtual User? UpdatedByNavigation { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
