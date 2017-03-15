using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest
{
    public class MainProcessor
    {
        private  IProcess _processor;
        public MainProcessor(IProcess processor)
        {
            _processor = processor;
        }

        public void Process()
        {
            if (Directory.Exists(Program.startFolder))
            {
                Process(Program.startFolder);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", Program.startFolder);
            }

        }

        private Task<IEnumerable<string>> GetFiles(string path)
        {
            return Task.Run<IEnumerable<string>>(() => Directory.GetFiles(path));
        }

        private Task<IEnumerable<string>> GetDirectories(string path)
        {
            return Task.Run<IEnumerable<string>>(() => Directory.GetDirectories(path));
        }

        private async void Process(string path)
        {
            var files = await GetFiles(path);

            Parallel.ForEach(files, (file) => 
                _processor.ProcessFile(file.Replace(Program.startFolder + @"\", String.Empty)));

            await GetDirectories(path).ContinueWith(async dirs => Parallel.ForEach(await dirs,(d) => Process(d)));
        }
    }
}