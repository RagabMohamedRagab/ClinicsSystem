using ClinicSystem.Helpers.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.Models.ResponseObjects {
    public class ResponseObject {
        public object Data { get; set; }
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
    }

}