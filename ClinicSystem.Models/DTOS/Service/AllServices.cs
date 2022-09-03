using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models.DTOS.Service {
    public class AllServices {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Notes { get; set; }
        public string ImageUrl { get; set; }
    }
}
