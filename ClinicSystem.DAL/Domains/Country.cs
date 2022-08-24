using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public class Country:BaseModel {
        public Country()
        {
            Cities=new HashSet<City>();
        }
        [Required]
        public string EnName { get; set; }
        [Required]
        public string ArName { get; set; }
        public virtual ICollection<City> Cities { get; set;}
    }
}
