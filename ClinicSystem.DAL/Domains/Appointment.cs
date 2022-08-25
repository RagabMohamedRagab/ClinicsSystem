using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class Appointment:BaseModel {
    
        [ForeignKey(nameof(Patient))]
        public Nullable<int> PatientId  { get; set;}
        public virtual Patient Patient { get; set;}
        [ForeignKey(nameof(User))]
        public string DoctorId { get; set;}
        public virtual ApplicationUser User { get; set;}
        public string Notes { get; set; }
        public int Number { get; set; }
        [ForeignKey(nameof(VisitType))]
        public Nullable<int> VisitTypeId { get; set; }
        public virtual VisitType VisitType { get; set; }
    }
}
