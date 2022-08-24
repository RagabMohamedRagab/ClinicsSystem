using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public class Drug :BaseModel{
        [Required]
        public string  EnName { get; set; }
        [Required]
        public string  ArName { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string EffectiveMaterial { get; set; }
        [Required]
        public string  Description { get; set; }
        [Required]
        public string Indications { get; set; }
        public virtual ICollection<PatientDrug> PatientDrugs { get; set; }
      

    }
}
