using ClinicSystem.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models.ResponseObjects {
    public class ResponseObject {
    
        private string ErrorCode = ErrorsCodes.Success.ToString();
        public string ErrorMessage {
            set
            {
                ErrorCode = value.ToString() ;
            }
            get
            {
                return ErrorCode.ToString();
            }
        }
        public object Data { get; set; }

    }

}