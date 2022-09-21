using Tracer.Core;

namespace Xml.DataTransferObjects
{
    public class MethodTraceInfoDTO
    {
        public string MethodName { get; set; }

        public string ClassName { get; set; }

        public long LeadTime { get; set; }

        public List<MethodTraceInfoDTO> NestedMethods { get; set; }


        [Obsolete("This constructor is meant to be used by the serializer.")]
        public MethodTraceInfoDTO()
        {

        }

        public MethodTraceInfoDTO(MethodTraceInfo methodTraceInfo)
        {
            MethodName = methodTraceInfo.MethodName;
            ClassName = methodTraceInfo.ClassName;
            LeadTime = methodTraceInfo.LeadTime;

            NestedMethods = new List<MethodTraceInfoDTO>();
            foreach (var m in methodTraceInfo.NestedMethods)
            {
                var item = new MethodTraceInfoDTO(m);
                NestedMethods.Add(item);
            }
        }
    }
}
