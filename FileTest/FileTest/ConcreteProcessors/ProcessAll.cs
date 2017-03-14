using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest.ConcreteProcessors
{
    public class ProcessAll: IProcess
    {
        public void ProcessFile(string path)
        {
            using (StreamWriter sw = File.AppendText(Program.resultFilePath))
            {
                sw.WriteLine(path.Replace(Program.startFolder+@"\", String.Empty));
            }
        }
    }
}
