using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class Package:BaseModel {
        [Required]
        [MaxLength(200)]
        public string EnName { get; set; }
        [Required]
        [MaxLength(200)]
        public string ArName { get; set; }
        [MaxLength(200)]
        public string Duration { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public long DisCount { get; set; }
        public virtual ICollection<ClinicPackage> Packages { get; set; }
        public virtual ICollection<PackageFeature> PackageFeatures { get; set;}
    }
}
