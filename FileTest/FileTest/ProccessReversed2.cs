using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest
{
    public class ProccessReversed2: IProcess
    {
        public void ProcessFile(string path)
        {
            Console.WriteLine("Processed file '{0}'.", path + "| file name: " + Path.GetFileNameWithoutExtension(path) + "| file extention: " + Path.GetExtension(path));
        }
        public string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
