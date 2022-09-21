using System.Collections.ObjectModel;

namespace Tracer.Core
{
    public partial class MethodTraceInfo
    {
        public string MethodName { get; private set; }

        public string ClassName { get; private set; }

        public long LeadTime { get; private set; }

        public ReadOnlyCollection<MethodTraceInfo> NestedMethods { get; }

        private List<MethodTraceInfo> _nestedMethods;


        private MethodTraceInfo(string methodName, string className)
        {
            MethodName = methodName;
            ClassName = className;
            _nestedMethods = new List<MethodTraceInfo>();
            NestedMethods = new ReadOnlyCollection<MethodTraceInfo>(_nestedMethods);
        }
    }
}
