using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Helpers.Enums {
    public enum Active {
        [Description("غير مفعل")]
        OFF=0,
        [Description(" مفعل")]
        ON =1
    }
}
