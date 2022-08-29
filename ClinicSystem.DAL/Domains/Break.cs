using ClinicSystem.Helper.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class Break:BaseModel {
        [Required]
        [MaxLength(200)]
        public string EnName { get; set; }
        [Required]
        [MaxLength(200)]
        public string ArName { get; set; }
        public virtual Week Weeek { get; set; }
        [DataType(DataType.Time)]
        public DateTime Start { get; set; }
        [DataType(DataType.Time)]
        public DateTime End { get; set; }
        public virtual Active Active { get; set; }
        [ForeignKey(nameof(Clinic))]
        public Nullable<int> ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
