using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianTrackingSystemApp.Data.Domain.Entities
{
    public class ClientChronicDisease :BaseEntity
    {
        public int ClientUserId { get; set; }
        public bool Diabetes { get; set; }
        public bool HighCholesterol { get; set; }
        public bool HeartRhythmDisorder { get; set; }
        public bool Atherosclerosis { get; set; }
        public bool BloodPressure { get; set; }

        public virtual User ClientUser { get; set; } = null!;
    }
}
