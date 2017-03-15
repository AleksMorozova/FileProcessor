using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest
{
    public class CommandLineArguments
    {
        [Option("s", Required = true, DefaultValue = @"D:\Main",
            HelpText = "Input file to be processed.")]
        public string StartFolder { get; set; }

        [Option("t", Required = true, DefaultValue = ActionType.all,
           HelpText = "Input file to be processed.")]
        public ActionType Type { get; set; }

        [Option("r", Required = false, DefaultValue = @"D:\result.txt",
            HelpText = "Input file to be processed.")]
        public string ResultFile { get; set; }
    }
}
