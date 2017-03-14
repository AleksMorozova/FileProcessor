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
                // This path is a directory
                //ProcessDirectory(Program.startFolder);
                Process(Program.startFolder);
               /* var concurrentBag = new ConcurrentBag<Task>();
                var concurrentBag2 = new ConcurrentBag<string>();
                ProcessDir(Program.startFolder, concurrentBag, concurrentBag2);
                Task.WaitAll(concurrentBag.ToArray());*/
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", Program.startFolder);
            }

        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.

        public void ProcessDirectory(string targetDirectory)
        {
            var fileEntries = Directory.GetFiles(targetDirectory);
            Task.WaitAll(fileEntries.Select(fileName => Task.Run(() => _processor.ProcessFile(fileName))).ToArray());

            var subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            Task.WaitAll(subdirectoryEntries.Select(subdirectory => Task.Run(() => ProcessDirectory(subdirectory))).ToArray());
        }

        public void ProcessDirectory2(string targetDirectory)
        {
            var fileEntries = Directory.GetFiles(targetDirectory);
            var subdirectoryEnries = Directory.GetDirectories(targetDirectory);

        }

        public void ProcessDir(string target, ConcurrentBag<Task> fileTasks, ConcurrentBag<string> fileNames)
        {
            foreach(var f in Directory.GetFiles(target)) { fileNames.Add(f); }
            var dirs = Directory.GetDirectories(target);
            var tasks = dirs.Select(s => Task.Run(() => ProcessDir(s, fileTasks, fileNames)));
            foreach (var t in tasks) fileTasks.Add(t);
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
            foreach(var file in files)
            {
                _processor.ProcessFile(file);
            }
            await GetDirectories(path).ContinueWith(async dirs => { foreach (var d in await dirs) { Process(d); } });
        }
    }
}
