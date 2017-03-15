using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest
{
    public interface IFileWrapper
    {
        string[] GetDirectiry(string path);
        string[] GetFiles(string path);
        bool Exists(string path);
    }
}
