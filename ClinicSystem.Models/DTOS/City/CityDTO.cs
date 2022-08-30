using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models.DTOS.City {
    public  class CityDTO {
        [Required]
        public string  EnName { get; set; }
        [Required]
        public string  ArName { get; set; }
        public int? CountryID { get; set; }
    }
}
