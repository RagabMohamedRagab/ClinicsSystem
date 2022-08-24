using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public class Package:BaseModel {
        [Required]
        public string EnName { get; set; }
        [Required]
        public string ArName { get; set; }
        public Guid Duration { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int DisCount { get; set; }
        public virtual ICollection<ClinicPackage> Packages { get; set; }
        public virtual ICollection<PackageFeature> PackageFeatures { get; set;}
    }
}
