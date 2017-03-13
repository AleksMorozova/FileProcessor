using Autofac;
using FileTest.ConcreteProcessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTest
{
    public static class Registration
    {
        public static IProcess processor;
        public static void Registrate(ActionType type)
        {
            processor = GetBuilder(type).Build().Resolve<IProcess>();
        }
        private static ContainerBuilder GetBuilder(ActionType type)
        {
            var builder = new ContainerBuilder();

            switch (type)
            {
                case ActionType.all:
                    builder.RegisterType<ProcessAll>().As<IProcess>();
                    break;
                case ActionType.cpp:
                    builder.RegisterType<ProcessorsCPP>().As<IProcess>();
                    break;
                case ActionType.reverse1:
                    builder.RegisterType<ProccessReversed1>().As<IProcess>();
                    break;
                case ActionType.reverse2:
                    builder.RegisterType<ProccessReversed2>().As<IProcess>();
                    break;
                default:
                    builder.RegisterType<ProcessAll>().As<IProcess>();
                    break;
            }
            return builder;
        }
    }
}
