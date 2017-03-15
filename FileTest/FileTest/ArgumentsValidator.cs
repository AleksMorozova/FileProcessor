using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest
{
    public class ArgumentsValidator : AbstractValidator<CommandLineArguments>
    {
        public ArgumentsValidator()
        {
            RuleFor(args => args.Type).IsInEnum().NotEmpty().WithMessage("Select one of existing action");
            RuleFor(args => args.StartFolder).NotEmpty().WithMessage("Please specify a start folder name");
        }

    }
}
