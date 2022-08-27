using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models.DTOS.Department {
    public class DepartMentDTO {
       
        [Required]
        public string ArName { get; set; }
        [Required]
        public string EnName { get; set; }
    }
}

