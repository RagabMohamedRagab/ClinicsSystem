using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models.DTOS.Service {
    public class ServiceDTO {
        [Required]
        public string EnName { get; set; }
        [Required]
        public string ArName { get; set; }
        public decimal Price { get; set; }
        public string Note { get; set; }
        [Required]
        public IFormFile File { get; set; }

    }
}

