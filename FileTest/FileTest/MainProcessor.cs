using System;
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
                ProcessDirectory(Program.startFolder);
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
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            List<Task> tasks = new List<Task>();
            foreach (string fileName in fileEntries)
            {
                Task task = Task.Run(() => _processor.ProcessFile(fileName));
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());

            List<Task> subTasks = new List<Task>();
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                Task task = Task.Run(() => ProcessDirectory(subdirectory));
                subTasks.Add(task);
            }
            Task.WaitAll(subTasks.ToArray());
        }
    }
}
