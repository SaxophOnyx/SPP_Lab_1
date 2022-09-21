using Tracer.Core;
using Xunit.Sdk;

namespace Tests
{
    [TestClass]
    public class ThreadTraceInfoBuilder
    {
        [TestMethod]
        public void Build_Test()
        {
            //arrange
            string firstMethodName = "FirstMethodName";
            string firstClassName = "FirstClassName";
            var firstMethodBuilder = new MethodTraceInfo.Builder(firstMethodName, firstClassName);
            firstMethodBuilder.StartWatch();
            Thread.Sleep(100);
            firstMethodBuilder.StopWatch();
            var firstMethod = firstMethodBuilder.Build();

            string secondMethodName = "FirstMethodName";
            string secondClassName = "FirstClassName";
            var secondMethodBuilder = new MethodTraceInfo.Builder(secondMethodName, secondClassName);
            secondMethodBuilder.StartWatch();
            Thread.Sleep(50);
            secondMethodBuilder.StopWatch();
            var secondMethod = secondMethodBuilder.Build();

            int id = 12;
            var builder = new ThreadTraceInfo.Builder(id);
            builder.AddMethodInfo(firstMethod);
            builder.AddMethodInfo(secondMethod);

            int methodNumber = 2;

            //act
            var threadInfo = builder.Build();

            //assert
            Assert.AreEqual(id, threadInfo.ThreadID);
            Assert.AreEqual(firstMethod.LeadTime + secondMethod.LeadTime, threadInfo.TotalTime);
            Assert.AreEqual(methodNumber, threadInfo.Methods.Count);
        }
    }
}
