using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public class City:BaseModel {
        [Required]
        public string EnName { get; set; }
        [Required]
        public string ArName { get; set; }
        [ForeignKey(nameof(Country))]
        public Nullable<int> CountryID { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
