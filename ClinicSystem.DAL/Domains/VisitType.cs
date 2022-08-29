using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class VisitType:BaseModel {
        public VisitType()
        {
            Appointments=new HashSet<Appointment>();
        }
        [MaxLength(200)]
        public string EnName { get; set; }
        [MaxLength(200)]
        public string ArName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
