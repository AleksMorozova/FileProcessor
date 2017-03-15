using Autofac;
using FluentValidation.Results;
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
            var options = new CommandLineArguments();
            ArgumentsValidator validator = new ArgumentsValidator();
            ValidationResult results = validator.Validate(options);

            if (results.IsValid)
            {
                CommandLine.Parser.Default.ParseArguments(args, options);
                resultFilePath = options.ResultFile;
                startFolder = options.StartFolder;
                Registration.Registrate(options.Type);
                var processor = new MainProcessor(Registration.processor, Registration.fileWrapper);
                processor.Process(startFolder);
                Console.WriteLine("End directory processing");
            }
            else
            {
                Console.WriteLine("Input correct parameters");
            }
         
            Console.ReadKey();
        }
    }
}
