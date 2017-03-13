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
        static void Main(string[] args)
        {
            Registration.Registrate(ActionType.all);      
            var processor = new MainProcessor(Registration.processor);
            processor.Process();
            Console.ReadKey();
        }
    }
}
