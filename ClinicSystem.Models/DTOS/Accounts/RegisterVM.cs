using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models.DTOS.Accounts {
    public class RegisterVM {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string NationalID { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Phone { get; set; }
        public int? GenderId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Eamil { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public IFormFile Photo { get; set; }
    }
}

