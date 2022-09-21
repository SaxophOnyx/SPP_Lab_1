using Tracer.Core;

namespace Tracer.Serialization
{
    namespace Abstraction
    {
        public interface ITraceResultSerializer
        {
            void Serialize(TraceResult traceResult, Stream to);
        }
    }
}
