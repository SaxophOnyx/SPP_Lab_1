using System.Collections.ObjectModel;

namespace Tracer.Core
{
    public partial class ThreadTraceInfo
    {
        public int ThreadID { get; }

        public long TotalTime { get; private set; }

        private List<MethodTraceInfo> _methods;

        public ReadOnlyCollection<MethodTraceInfo> Methods { get; }


        private ThreadTraceInfo(int threadID)
        {
            ThreadID = threadID;
            _methods = new List<MethodTraceInfo>();
            Methods = new ReadOnlyCollection<MethodTraceInfo>(_methods);
        }
    }
}
