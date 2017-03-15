using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
                Console.WriteLine("{0} is not a valid file or directory.", Program.startFolder);
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
            foreach(var file in files)
            {
                _processor.ProcessFile(file);
            }
            await GetDirectories(path).ContinueWith(async dirs => { foreach (var d in await dirs) { Process(d); } });
        }
    }
}
