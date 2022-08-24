using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public class DepartMent:BaseModel {
        public DepartMent()
        {
            Users = new HashSet<ApplicationUser>();
        }
        [Required,MaxLength(200)]
        public string ArName { get; set; }
        [Required, MaxLength(200)]
        public string EnName { get; set; }
    public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
