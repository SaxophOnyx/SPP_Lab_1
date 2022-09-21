using YamlDotNet.Serialization;
using Tracer.Core;
using Tracer.Serialization.Abstraction;

namespace Tracer.Yaml
{
    public class YamlTraceResultSerializer : ITraceResultSerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            var yaml = new SerializerBuilder().Build();
            using (var stream = new StreamWriter(to))
            {
                yaml.Serialize(stream, traceResult, typeof(TraceResult));
            }
        }
    }
}