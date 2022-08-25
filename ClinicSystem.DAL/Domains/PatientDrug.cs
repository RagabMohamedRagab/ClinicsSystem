using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class PatientDrug:BaseModel {
        [ForeignKey(nameof(Patient))]
        public Nullable<int> PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        [ForeignKey(nameof(Drug))]
        public Nullable<int> DrugID { get; set; }
        public virtual Drug Drug { get; set; }
    }
}
