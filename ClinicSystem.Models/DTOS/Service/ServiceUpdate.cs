using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models.DTOS.Service {
    public class ServiceUpdate {
        [Required]
        public decimal Price { get; set; }
        public string Note { get; set; }
        public string ImgUrl{ get; set; }
    }
}
