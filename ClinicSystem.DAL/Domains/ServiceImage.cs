using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public class ServiceImage :BaseModel{
        public Nullable<int> ServiceId  { get; set; }
        public virtual Service Service { get; set; }
        public string ImageUrl { get; set; }
    }
}
