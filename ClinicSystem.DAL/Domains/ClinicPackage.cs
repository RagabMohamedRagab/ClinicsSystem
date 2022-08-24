using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public class ClinicPackage:BaseModel {
        [ForeignKey(nameof(Clinic))]
        public Nullable<int> ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }
        [ForeignKey(nameof(Package))]
        public Nullable<int> PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}
