using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(200)]
        public string Notes { get; set; }
        public int Number { get; set; }

    }
}
