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
            using (StreamWriter sw = File.AppendText(Program.ResultFilePath))
            {
                sw.WriteLine(ReverseString(path));
            }
        }

        private string ReverseString(string path)
        {
            StringBuilder result = new StringBuilder();

            var subStrings = path.Split('\\').ToList();
            foreach (var substring in subStrings)
            {
                result.Append(new string(substring.Reverse().ToArray()));
                result.Append('\\');
            }
            if (result.ToString().EndsWith("\\"))
            {
                result.Remove(result.Length - 1, 1);
            }
            return result.ToString();
        }
    }
}
