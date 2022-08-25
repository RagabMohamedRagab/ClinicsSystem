using ClinicSystem.DAL.Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Context {
    public partial class ClinicDbContext :IdentityDbContext<ApplicationUser>{
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options):base(options){}
        
     public virtual DbSet<Appointment> Appointments { get; set; } 
     public virtual DbSet<AppUserClinic> AppUserClinics { get; set; } 
     public virtual DbSet<Break> Breaks { get; set; } 
     public virtual DbSet<City> Cities { get; set; } 
     public virtual DbSet<Clinic> Clinics { get; set; } 
     public virtual DbSet<ClinicImage> ClinicImages { get; set; } 
     public virtual DbSet<ClinicPackage> ClinicPackages { get; set; } 
     public virtual DbSet<ClinicService> ClinicServices { get; set; } 
     public virtual DbSet<Country> Countries { get; set; } 
     public virtual DbSet<DepartMent> DepartMents { get; set; } 
     public virtual DbSet<Drug> Drugs { get; set; } 
     public virtual DbSet<FoodSystem> FoodSystems { get; set; }
      public virtual DbSet<PackageFeature> PackageFeatures { get; set; }
      public virtual DbSet<Patient> Patients { get; set; }
      public virtual DbSet<PatientDrug> PatientDrugs { get; set; }
      public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceImage> ServiceImages { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<VisitType> VisitTypes { get; set; }
        public virtual DbSet<Ray> Rays { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  
        }
    }
}
