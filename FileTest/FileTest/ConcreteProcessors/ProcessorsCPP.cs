using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest.ConcreteProcessors
{
    public class ProcessorsCPP : IProcess
    {
        public void ProcessFile(string path)
        {
            using (StreamWriter sw = File.AppendText(Program.ResultFilePath))
            {
                if (Path.GetExtension(path) == ".cpp")
                    sw.WriteLine(path);
            }
        }
    }
}
