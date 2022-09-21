namespace Tracer.Core
{
    public partial class TraceResult
    {
        public class Builder
        {
            private TraceResult _traceResult;


            public Builder()
            {
                _traceResult = new TraceResult();
            }


            public TraceResult Build()
            {
                return _traceResult;
            }


            public Builder AddThreadTraceInfo(ThreadTraceInfo info)
            {
                _traceResult._threadsInfo.Add(info);
                return this;
            }
        }
    }
}
