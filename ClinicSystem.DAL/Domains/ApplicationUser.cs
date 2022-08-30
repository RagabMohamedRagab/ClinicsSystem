using ClinicSystem.Helpers.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class ApplicationUser : IdentityUser {
        public ApplicationUser()
        {
            Appointments = new HashSet<Appointment>();
        }
        [Required]
        [MaxLength(200)]
        public string FullName { get; set; }
        [MaxLength(200)]
        public string About { get; set; }
        [Required]
        [MaxLength(14)]
        public string NationalID { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(200)]
        public string LandLine { get; set; }
        public virtual Gender Gender { get; set; }
        public int AccountNumber { get; set; }
        [MaxLength(200)]
        public string BankName { get; set; }
        [MaxLength(200)]
        public string Note { get; set; }
        public string ImgUrl { get; set; }
        [ForeignKey(nameof(DepartMent))]
        public Nullable<int> DepartId { get; set; }
        public virtual DepartMent DepartMent { get; set; }
        [ForeignKey(nameof(Country))]
        public Nullable<int> CountryId { get; set; }
        public virtual Country Country { get; set; }
        [ForeignKey(nameof(City))]
        public Nullable<int> CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<AppUserClinic> AppUserClinics { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}




