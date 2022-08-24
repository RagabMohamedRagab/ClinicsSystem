using ClinicSystem.Helper.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public class Shift:BaseModel {
        [Required]
        public string EnName { get; set; }
        [Required]
        public string ArName { get; set; }
       [DataType(DataType.Time)]
        public DateTime Start { get; set; }
        [DataType(DataType.Time)]
        public DateTime End{ get; set; }
        public Active active { get; set; }
        [ForeignKey(nameof(Clinic))]
        public Nullable<int> ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
