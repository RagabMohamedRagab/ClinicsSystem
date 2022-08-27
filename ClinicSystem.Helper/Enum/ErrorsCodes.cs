using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Helpers.Enum {
    public enum ErrorsCodes {
        Success = 0,
        InvalidObject=1,
        NamesAreNull=2,
        IDNotValid=3,
        InvalidUpadte=4,
        NotSaveChangesInDatabase=5,
        ThrowException=6,
        ParameteresNotCorrect=7
    }
}
