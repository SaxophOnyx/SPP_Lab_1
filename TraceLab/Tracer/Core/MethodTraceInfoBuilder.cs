using System.Diagnostics;

namespace Tracer.Core
{
    public partial class MethodTraceInfo
    {
        public class Builder
        {
            private Stopwatch _stopwatch;

            private MethodTraceInfo _methodTraceInfo;

            public bool IsWatchRunning
            {
                get { return _stopwatch.IsRunning; }
            }


            public Builder(string methodName, string className)
            {
                _methodTraceInfo = new MethodTraceInfo(methodName, className);
                _stopwatch = new Stopwatch();
            }


            public MethodTraceInfo Build()
            {
                return _methodTraceInfo;
            }

            public Builder StartWatch()
            {
                _stopwatch.Start();
                return this;
            }

            public Builder StopWatch()
            {
                _stopwatch.Stop();
                _methodTraceInfo.LeadTime += _stopwatch.ElapsedMilliseconds;
                return this;
            }

            public Builder AddNestedMethod(MethodTraceInfo info)
            {
                _methodTraceInfo._nestedMethods.Add(info);
                return this;
            }
        }
    }
}
