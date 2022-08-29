using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models.DTOS.Country {
    public class CountryCreateDTO {

        public string  EnName { get; set; }
  
        public string  ArName { get; set; }
        public IFormFile Logo { get; set; }
    }
}
