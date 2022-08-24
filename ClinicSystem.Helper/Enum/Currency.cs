using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Helper.Enum {
    public enum Currency {
        [Description("Egyptian pound,")]
        EGP=0,
        [Description("United States dollar")]
        USD=1,
        [Description("Saudi riyal")]
        SR=2,
    }
}
