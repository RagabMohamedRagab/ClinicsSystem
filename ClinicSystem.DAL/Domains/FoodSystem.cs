using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class FoodSystem:BaseModel {
        [Required]
        [MaxLength(200)]
        public string Protein { get; set; }
        [Required]
        [MaxLength(200)]
        public string Oils { get; set; }
        [Required]
        [MaxLength(200)]
        public string Fruits { get; set; }
        [Required]
        [MaxLength(200)]
        public string EnDescription { get; set; }
        [Required]
        [MaxLength(200)]
        public string ArDescription { get; set; }
        [ForeignKey(nameof(Patient))]
        public Nullable<int> PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}



