using System.Collections.ObjectModel;

namespace Tracer.Core
{
    public partial class TraceResult
    {
        private List<ThreadTraceInfo> _threadsInfo;

        public ReadOnlyCollection<ThreadTraceInfo> ThreadsInfo { get; }


        public TraceResult()
        {
            _threadsInfo = new List<ThreadTraceInfo>();
            ThreadsInfo = new ReadOnlyCollection<ThreadTraceInfo>(_threadsInfo);
        }
    }
}
