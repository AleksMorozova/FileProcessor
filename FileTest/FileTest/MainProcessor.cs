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
        private  IProcess _repository;
        public MainProcessor(IProcess repository)
        {
            _repository = repository;
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
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                _repository.ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
    }
}
