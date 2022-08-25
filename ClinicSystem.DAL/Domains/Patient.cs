using ClinicSystem.Helper.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string FullName { get; set; }
        [Required]
        public string NationalID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public int PolicyName { get; set; }
        public int Insurancenumber{get;set;}
        [Required]
        public string Phone1 { get; set; }
        public string phone2 { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } 
        public virtual ICollection<FoodSystem> FoodSystems { get; set; }
        public virtual ICollection<PatientDrug> PatientDrugs { get; set; }
        public virtual ICollection<Ray> Rays { get; set; }

    }
}
