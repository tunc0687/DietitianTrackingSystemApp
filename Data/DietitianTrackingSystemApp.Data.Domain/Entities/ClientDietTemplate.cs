using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianTrackingSystemApp.Data.Domain.Entities
{
    public class ClientDietTemplate : BaseEntity
    {
        public int ClientUserId { get; set; }
        public int DietTemplateId { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set;}

        public virtual User ClientUser { get; set; } = null!;
        public virtual DietTemplate DietTemplate { get; set; } = null!;
    }
}
