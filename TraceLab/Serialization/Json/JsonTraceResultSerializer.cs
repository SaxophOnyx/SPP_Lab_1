using System.Text.Json;
using Tracer.Core;
using Tracer.Serialization.Abstraction;

namespace Tracer.Json
{
    public class JsonTraceResultSerializer : ITraceResultSerializer
    {
        public int A { get; set; }


        public JsonTraceResultSerializer()
        {
            A = 1;
        }


        public void Serialize(TraceResult traceResult, Stream to)
        {
            JsonSerializer.Serialize(to, traceResult, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}