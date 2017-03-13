using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest.ConcreteProcessors
{
    public class ProccessReversed1 : IProcess
    {
        public void ProcessFile(string path)
        {
            using (StreamWriter sw = File.AppendText(Program.resultFilePath))
            {
                sw.WriteLine(ReverseString(path));
            }
        }
        public string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
