using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest
{ 
    class Program
    {
        public static string resultFilePath = @"D:\result.txt";
        public static string startFolder = @"D:\Main";
        static void Main(string[] args)
        {
            var options = new Options();
            CommandLine.Parser.Default.ParseArguments(args, options);

            resultFilePath = options.ResultFile;
            startFolder = options.StartFolder;

            Registration.Registrate(options.Type);      
            var processor = new MainProcessor(Registration.processor);
            processor.Process();
            Console.WriteLine("End directory processing");
            Console.ReadKey();
        }
    }
}
