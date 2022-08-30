using ClinicSystem.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class Shift:BaseModel {
        [Required]
        [MaxLength(200)]
        public string EnName { get; set; }
        [Required]
        [MaxLength(200)]
        public string ArName { get; set; }
       [DataType(DataType.Time)]
        [Column(TypeName = "datetime2(7)")]
        public DateTime Start { get; set; }
        [DataType(DataType.Time)]
        [Column(TypeName = "datetime2(7)")]
        public DateTime End{ get; set; }
        public Active active { get; set; }
        [ForeignKey(nameof(Clinic))]
        public Nullable<int> ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }
    }
}
