using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianTrackingSystemApp.Data.Domain.Entities
{
    public class ClientConsultant : BaseEntity
    {
        public int ClientUserId { get; set; }
        public int ConsultantUserId { get; set; }

        public virtual User ClientUser { get; set; } = null!;
        public virtual User ConsultantUser { get; set; } = null!;
    }
}
