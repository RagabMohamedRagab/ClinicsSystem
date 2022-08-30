using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Helpers.Enums {
    public enum MaritalStatus {
        [Description("اعزب")]
        Single=1,
        [Description("متزوج-متزوجه")]
        Married=2,
        [Description("مطلق - مطلقه")]
        Divorced=3
    }
}
