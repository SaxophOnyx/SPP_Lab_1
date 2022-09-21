using Tracer.Core;

namespace Xml.DataTransferObjects
{
    public class TraceResultDTO
    {
        public List<ThreadTraceInfoDTO> ThreadsInfo { get; set; }


        [Obsolete("This constructor is meant to be used by the serializer.")]
        public TraceResultDTO()
        {

        }

        public TraceResultDTO(TraceResult result)
        {
            ThreadsInfo = new List<ThreadTraceInfoDTO>();
            foreach (var t in result.ThreadsInfo)
            {
                var item = new ThreadTraceInfoDTO(t);
                ThreadsInfo.Add(item);
            }
        }
    }
}
