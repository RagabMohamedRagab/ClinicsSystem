using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public class Gender:BaseModel {
        [Required]
        [MaxLength(120)]
       public string EnGender { get; set; }
      [Required]
      [MaxLength(120)]
        public string ArGender { get; set; }
    }
}
