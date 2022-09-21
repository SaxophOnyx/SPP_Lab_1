using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;

namespace Tracer.Core
{
    public class Tracer : ITracer
    {
        private TraceResult.Builder _traceResultBuilder;

        private ConcurrentDictionary<int, ThreadTraceInfo.Builder> _threads;


        public Tracer()
        {
            _traceResultBuilder = new TraceResult.Builder();
            _threads = new ConcurrentDictionary<int, ThreadTraceInfo.Builder>();
        }


        public TraceResult GetTraceResult()
        {
            foreach (var builder in _threads)
            {
                _traceResultBuilder.AddThreadTraceInfo(builder.Value.Build());
            }

            return _traceResultBuilder.Build();
        }

        public void StartTrace()
        {
            int id = Environment.CurrentManagedThreadId;
            _threads.TryGetValue(id, out var threadBuilder);

            if (threadBuilder == null)
            {
                threadBuilder = new ThreadTraceInfo.Builder(id);
                _threads.TryAdd(id, threadBuilder);
            }

            StackFrame frame = new StackFrame(1);
            MethodBase method = frame.GetMethod();

            var builder = new MethodTraceInfo.Builder(method.Name, method.DeclaringType.Name);
            threadBuilder.PushMethod(builder);
            builder.StartWatch();
        }

        public void StopTrace()
        {
            int id = Environment.CurrentManagedThreadId;
            _threads.TryGetValue(id, out var threadBuilder);
            var method = threadBuilder.PopMethod().StopWatch().Build();
            threadBuilder.AddMethodInfo(method);
        }
    }
}