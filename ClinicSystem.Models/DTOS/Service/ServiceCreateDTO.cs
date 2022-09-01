using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models.DTOS.Service {
    public class ServiceCreateDTO {
      
        public string EnName { get; set; }
     
        public string ArName { get; set; }
   
        public decimal Price { get; set; }

        public string Notes { get; set; }
        public string ImageUrl { get; set; }
    }
}
