using ClinicSystem.BOL.IServices;
using ClinicSystem.Helpers.Enums;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace ClinicSystem.BLL.Services {
    public class FileService : IFileService {
        private readonly IHostingEnvironment _hosting;

        public FileService(IHostingEnvironment hosting)
        {
            _hosting = hosting;
        }

        public bool AllowExtension(string path)
        {
            List<string> Extension = new List<string>() { ".jpg", ".png" };
            if (Extension.Contains(Path.GetExtension(path).ToLower()))
                return true;
            return false;

        }

        public string Create(IFormFile file, Folder Type)
        {
            string fileName = string.Empty;
            if (file != null)
            {
                if (AllowExtension(file.FileName))
                {
                    string Folder = Path.Combine(_hosting.WebRootPath, Type.ToString());
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    fileName = file.FileName;
                    string FullPath = Path.Combine(Folder, fileName);
                    var stream = new FileStream(FullPath, FileMode.Create);
                    file.CopyTo(stream);
                    stream.Close();
                    return fileName; 
                }
            }
            return null;
        }

        public bool Find(string path, Folder Type)
        {
            if (path != null)
            {
                string Folder = Path.Combine(_hosting.WebRootPath, Type.ToString());
                string FullPath = Path.Combine(Folder, path);
                if (File.Exists(FullPath))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string path, Folder Type)
        {
            if (path != null)
            {
                string Folder = Path.Combine(_hosting.WebRootPath, Type.ToString());
                string FullPath = Path.Combine(Folder, path);
                if (File.Exists(FullPath))
                {
                    File.Delete(FullPath);
                    return true;
                }
            }
            return false;
        }

     

    
    }
}

