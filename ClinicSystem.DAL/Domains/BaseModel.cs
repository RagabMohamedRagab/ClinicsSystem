using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "datetime2(7)")]
        public DateTime CraetedOn { get; set; }
        [DataType(DataType.DateTime)]
          [Column(TypeName = "datetime2(7)")]
        public Nullable<DateTime> ModifiedOn{get;set;}
        [DataType(DataType.DateTime)]
        public  Nullable<DateTime> DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
