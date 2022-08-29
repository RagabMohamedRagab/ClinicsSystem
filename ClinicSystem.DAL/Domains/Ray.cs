using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class Ray : BaseModel {
        [Required]
        [MaxLength(200)]
        public string EnName { get; set; }
        [Required]
        [MaxLength(200)]
        public string ArName { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Patient))]
        public Nullable<int> PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}

