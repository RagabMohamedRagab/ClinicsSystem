using ClinicSystem.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class Patient : BaseModel {
        public Patient()
        {
            Appointments=new HashSet<Appointment>();
            FoodSystems=new HashSet<FoodSystem>();
            PatientDrugs=new HashSet<PatientDrug>();
        }
        [Required]
        [MaxLength(200)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(20)]
        public string NationalID { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(200)]
        public string CompanyName { get; set; }
        public int PolicyName { get; set; }
        public int Insurancenumber{get;set;}
        [Required]
        [MaxLength(20)]
        public string Phone1 { get; set; }
        [MaxLength(20)]
        public string phone2 { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(200)]
        public string Note { get; set; }
        [ForeignKey(nameof(Gender))]
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        [ForeignKey(nameof(MaritalStatus))]
        public int? MaritalStatusId { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } 
        public virtual ICollection<FoodSystem> FoodSystems { get; set; }
        public virtual ICollection<PatientDrug> PatientDrugs { get; set; }
        public virtual ICollection<Ray> Rays { get; set; }

    }
}
