using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models.DTOS.Gender {
    public class GenderDTO {
        [Required]
        public string EnGender { get; set; }
      [Required]
       public string ArGender { get; set; }
    }
}
