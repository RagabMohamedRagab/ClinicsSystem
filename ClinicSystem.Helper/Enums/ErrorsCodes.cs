using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Helpers.Enums{
    public enum ErrorsCodes {
        Success = 0,
        InvalidObject=1,
        NamesAreNull=2,
        IDNotValid=3,
        InvalidUpadte=4,
        NotSaveChangesInDatabase=5,
        ThrowException=6,
        ParameteresNotCorrect=7,
        ImageIsNotValid=8,
        ExtentioPNGANDJPG=9,
        InvalidDelete = 10,
        NotFound=11,
        InvalidAdd=12
    }
}
