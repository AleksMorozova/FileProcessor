using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileTest;
using FileTest.ConcreteProcessors;
using System.Collections.Generic;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] dir = new string[1];
            dir[0] = @"D:\Main\First";

            IFileWrapper fileWrapperDependency =
                Mock.Of<IFileWrapper>(d => d.GetDirectiry("") == dir);
            var currentDirectory = fileWrapperDependency.GetDirectiry("");

            var sut = new MainProcessor(new ProccessReversed1(),
                fileWrapperDependency).GetDirectories("");

            var result = sut.Result;

            List<string> list = new List<string>();
            foreach (var item in result)
            {
                list.Add(item);
            }

            Assert.IsTrue(list.Contains(@"D:\Main\First"));
        }
    }
}
