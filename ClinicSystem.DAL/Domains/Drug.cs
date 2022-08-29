using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class Drug :BaseModel{
        [Required]
        [MaxLength(200)]
        public string  EnName { get; set; }
        [Required]
        [MaxLength(200)]
        public string  ArName { get; set; }
        [Required]
        [MaxLength(200)]
        public string CompanyName { get; set; }
        [Required]
        [MaxLength(200)]
        public string EffectiveMaterial { get; set; }
        [Required]
        [MaxLength(200)]
        public string  Description { get; set; }
        [Required]
        [MaxLength(200)]
        public string Indications { get; set; }
        public virtual ICollection<PatientDrug> PatientDrugs { get; set; }
      

    }
}
