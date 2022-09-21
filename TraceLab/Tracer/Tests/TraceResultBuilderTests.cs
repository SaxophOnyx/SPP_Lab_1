using Xunit.Sdk;
using Tracer.Core;

namespace Tests
{
    [TestClass]
    public class TraceResultBuilderTests
    {
        [TestMethod]
        public void AddThreadTraceInfo_Test()
        {
            //arrange
            int id = 12;
            ThreadTraceInfo.Builder threadBuilder = new ThreadTraceInfo.Builder(id);
            ThreadTraceInfo threadTraceInfo = threadBuilder.Build();
            TraceResult.Builder builder = new TraceResult.Builder();

            //act
            builder.AddThreadTraceInfo(threadTraceInfo);
            TraceResult traceResult = builder.Build();

            //assert
            Assert.AreEqual(1, traceResult.ThreadsInfo.Count);
        }

        public void Build_Test()
        {
            //arrange
            int id = 12;
            ThreadTraceInfo.Builder threadBuilder = new ThreadTraceInfo.Builder(id);
            ThreadTraceInfo threadTraceInfo = threadBuilder.Build();
            TraceResult.Builder builder = new TraceResult.Builder();

            //act
            builder.AddThreadTraceInfo(threadTraceInfo);
            TraceResult traceResult = builder.Build();

            //assert
            Assert.AreEqual(threadTraceInfo, traceResult.ThreadsInfo[0]);
        }
    }
}
