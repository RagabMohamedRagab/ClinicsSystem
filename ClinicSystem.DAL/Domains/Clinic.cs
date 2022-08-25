using ClinicSystem.Helper.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class Clinic:BaseModel {
        public Clinic()
        {
            ClinicImages=new HashSet<ClinicImage>();
            ClinicServices = new HashSet<ClinicService>();
            Shifts=new HashSet<Shift>();
            Breaks = new HashSet<Break>();
            ClinicPackages=new HashSet<ClinicPackage>();
        }
        [Required]
        public string EnName { get; set; }
        [Required]
        public string  ArName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string LandLine { get; set; }
        public string Logo { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public string Eamil { get; set; }
        [DataType(DataType.Currency)]
        public virtual Currency Currency { get; set; }
        [DataType(DataType.Time)]
        public DateTime DetectionTime { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string TikTokUrl { get; set; }
        public string InstagramUrl { get; set; }
        public virtual ICollection<ClinicPackage>  ClinicPackages { get; set; }
        public virtual ICollection<ClinicImage> ClinicImages { get; set; }
        public virtual ICollection<ClinicService> ClinicServices { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
        public virtual ICollection<Break> Breaks { get; set; }
        public virtual ICollection<AppUserClinic> AppUserClinics { get; set; }


    }
}
