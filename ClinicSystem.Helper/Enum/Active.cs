using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Helper.Enum {
    public enum Active {
        [Description("غير مفعل")]
        OFF=0,
        [Description(" مفعل")]
        ON =1
    }
}
