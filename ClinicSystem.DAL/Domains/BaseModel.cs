using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.DAL.Domains {
    public partial class BaseModel {
        public BaseModel()
        {
            CraetedOn = DateTime.Now;
            IsDeleted = false;
        }
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CraetedOn { get; set; }
        [DataType(DataType.DateTime)]
        public Nullable<DateTime> ModifiedOn{get;set;}
        public bool IsDeleted { get; set; }

    }
}
