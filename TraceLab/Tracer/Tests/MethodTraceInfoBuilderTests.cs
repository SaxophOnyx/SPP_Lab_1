using Tracer.Core;
using Xunit.Sdk;

namespace Tests
{
    [TestClass]
    public class MethodTraceInfoBuilderTests
    {
        [TestMethod]
        public void StartWatch_Test()
        {
            //arrange
            MethodTraceInfo.Builder builder = new MethodTraceInfo.Builder(string.Empty, string.Empty);

            //act
            builder.StartWatch();

            //assert
            Assert.IsTrue(builder.IsWatchRunning);
        }

        [TestMethod]
        public void StopWatch_Test()
        {
            //arrange
            MethodTraceInfo.Builder builder = new MethodTraceInfo.Builder(string.Empty, string.Empty);
            builder.StartWatch();

            //act
            builder.StopWatch();

            //assert
            Assert.IsFalse(builder.IsWatchRunning);
        }

        [TestMethod]
        public void Build_Test()
        {
            //arrange
            string className = "ClassName";
            string methodName = "MethodName";
            MethodTraceInfo.Builder builder = new MethodTraceInfo.Builder(methodName, className);

            //act
            MethodTraceInfo info = builder.Build();

            //assert
            Assert.AreEqual(className, info.ClassName);
            Assert.AreEqual(methodName, info.MethodName);
            Assert.AreEqual(0, info.NestedMethods.Count);
        }
    }
}