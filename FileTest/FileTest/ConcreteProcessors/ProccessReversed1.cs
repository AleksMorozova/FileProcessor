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
                sw.WriteLine(ReverseString(path.Replace(Program.startFolder + @"\", String.Empty)));
            }
        }

        private string ReverseString(string path)
        {
            StringBuilder result = new StringBuilder();

            var substrings = path.Split('\\').ToList();
            foreach (var substring in substrings)
            {
                result.Append('\\');
                result.Append(new string(substring.Reverse().ToArray()));
            }
            return result.ToString();
        }
    }
}
