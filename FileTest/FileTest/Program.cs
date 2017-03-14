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
            System.Console.WriteLine(args.Length);

            Registration.Registrate(ActionType.reverse1);      
            var processor = new MainProcessor(Registration.processor);
            processor.Process();
            Console.WriteLine("End directory processing");
            Console.ReadKey();
        }
    }
}
