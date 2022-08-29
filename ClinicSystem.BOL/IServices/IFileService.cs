using ClinicSystem.Helpers.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem.BOL.IServices {
    public  interface IFileService {
        string Create(IFormFile  file,Folder Type );
        bool AllowExtension(string path);
        bool Remove(string path, Folder Type);
        bool Find(string path, Folder Type);
    }
}
