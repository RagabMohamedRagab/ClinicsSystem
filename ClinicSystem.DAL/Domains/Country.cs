using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class Country:BaseModel {
        public Country()
        {
            Cities=new HashSet<City>();
        }
        [Required]
        [MaxLength(200)]
        public string EnName { get; set; }
        [Required]
        [MaxLength(200)]
        public string ArName { get; set; }
        public string Logo { get; set; }
        public virtual ICollection<City> Cities { get; set;}
    }
}
