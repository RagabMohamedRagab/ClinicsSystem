using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public class VisitType:BaseModel {
        public VisitType()
        {
            Appointments=new HashSet<Appointment>();
        }
        public string EnName { get; set; }
        public string ArName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
