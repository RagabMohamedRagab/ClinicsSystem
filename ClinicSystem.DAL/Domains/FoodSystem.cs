using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public class FoodSystem:BaseModel {
        [Required]
        public string Protein { get; set; }
        [Required]
        public string Oils { get; set; }
        [Required]
        public string Fruits { get; set; }
        [Required]
        public string EnDescription { get; set; }
        [Required]
        public string ArDescription { get; set; }
        [ForeignKey(nameof(Patient))]
        public Nullable<int> PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}



