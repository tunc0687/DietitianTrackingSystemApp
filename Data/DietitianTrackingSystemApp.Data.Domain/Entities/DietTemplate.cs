using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianTrackingSystemApp.Data.Domain.Entities
{
    public class DietTemplate : BaseEntity
    {
        public DietTemplate()
        {
            ClientDietTemplates = new HashSet<ClientDietTemplate>();
        }

        public string DietName { get; set; } = null!;
        public string Definition { get; set; } = null!;

        public virtual ICollection<ClientDietTemplate> ClientDietTemplates { get; set; }
    }
}
