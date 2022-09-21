using System.Xml.Serialization;
using Tracer.Core;
using Tracer.Serialization.Abstraction;
using Xml.DataTransferObjects;

namespace Tracer.Xml
{
    public class XmlTraceResultSerializer : ITraceResultSerializer
    {
        public void Serialize(TraceResult traceResult, Stream to)
        {
            var xml = new XmlSerializer(typeof(TraceResultDTO), new XmlWriterSettings() { Indent = true });
            var dto = new TraceResultDTO(traceResult);
            xml.Serialize(to, dto);
        }
    }
}