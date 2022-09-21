using Tracer.Core;

namespace Xml.DataTransferObjects
{
    public class ThreadTraceInfoDTO
    {
        public int ThreadID { get; set; }

        public long TotalTime { get; set; }

        public List<MethodTraceInfoDTO> Methods { get; set; }


        [Obsolete("This constructor is meant to be used by the serializer.")]
        public ThreadTraceInfoDTO()
        {

        }

        public ThreadTraceInfoDTO(ThreadTraceInfo threadTraceInfo)
        {
            ThreadID = threadTraceInfo.ThreadID;
            TotalTime = threadTraceInfo.TotalTime;

            Methods = new List<MethodTraceInfoDTO>();
            foreach (var m in threadTraceInfo.Methods)
            {
                var item = new MethodTraceInfoDTO(m);
                Methods.Add(item);
            }
        }
    }
}
