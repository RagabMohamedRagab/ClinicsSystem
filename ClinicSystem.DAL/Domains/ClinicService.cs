using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public class ClinicService:BaseModel {
        [ForeignKey(nameof(Clinic))]
        public Nullable<int> ClinicId { get; set; }
       public virtual Clinic Clinic { get; set; }
        [ForeignKey(nameof(Service))]
        public Nullable<int> ServiceId { get; set; }
        public virtual Service Service { get; set; }
    }
}
