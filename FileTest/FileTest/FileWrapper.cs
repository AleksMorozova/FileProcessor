using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest
{
    public class FileWrapper :IFileWrapper
    {
        public string[] GetDirectiry(string path)
        {
            return Directory.GetDirectories(path);
        }
        public string[] GetFiles(string path)
        {
            return Directory.GetFiles(path);
        }
        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }
    }
}
