using System.Text.Json;
using Tracer.Core;
using Tracer.Serialization.Abstraction;

namespace Tracer.Json
{
    public class JsonTraceResultSerializer : ITraceResultSerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            JsonSerializer.Serialize(to, traceResult, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}