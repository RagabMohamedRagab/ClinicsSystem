using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public class ClinicImage : BaseModel {
        public Nullable<int> ClinicID { get; set; }
        public virtual Clinic Clinic { get; set; }
        public string Image { get; set; }
        public string Notes { get; set; }
    }
}


