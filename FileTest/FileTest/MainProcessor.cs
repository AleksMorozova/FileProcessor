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
        private IFileWrapper _fileWrapper;
        public MainProcessor(IProcess processor, IFileWrapper fileWrapper)
        {
            _processor = processor;
            _fileWrapper = fileWrapper;
        }

        public void Process(string path)
        {
            if (_fileWrapper.Exists(path))
            {
                ProcessDirectory(path);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }

        }

        public Task<IEnumerable<string>> GetFiles(string path)
        {
            return Task.Run<IEnumerable<string>>(() => _fileWrapper.GetFiles(path));
        }

        public Task<IEnumerable<string>> GetDirectories(string path)
        {
            return Task.Run<IEnumerable<string>>(() => _fileWrapper.GetDirectiry(path));
        }

        public async void ProcessDirectory(string path)
        {
            var files = await GetFiles(path);

            Parallel.ForEach(files, (file) => 
                _processor.ProcessFile(file.Replace(path + @"\", String.Empty)));

            await GetDirectories(path).ContinueWith(async dirs => Parallel.ForEach(await dirs,(d) => Process(d)));
        }
    }
}
