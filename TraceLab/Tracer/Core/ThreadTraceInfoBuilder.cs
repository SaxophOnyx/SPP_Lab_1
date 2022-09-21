namespace Tracer.Core
{
    public partial class ThreadTraceInfo
    {
        public class Builder
        {
            private ThreadTraceInfo _threadTraceInfo;

            private Stack<MethodTraceInfo.Builder> _methodStack;


            public Builder(int threadID)
            {
                _threadTraceInfo = new ThreadTraceInfo(threadID);
                _methodStack = new Stack<MethodTraceInfo.Builder>();
            }


            public ThreadTraceInfo Build()
            {
                foreach (var method in _threadTraceInfo.Methods)
                {
                    _threadTraceInfo.TotalTime += method.LeadTime;
                }

                return _threadTraceInfo;
            }

            public Builder AddMethodInfo(MethodTraceInfo method)
            {
                if (_methodStack.Count > 0)
                    _methodStack.Peek().AddNestedMethod(method);
                else
                    _threadTraceInfo._methods.Add(method);

                return this;
            }

            public Builder PushMethod(MethodTraceInfo.Builder method)
            {
                _methodStack.Push(method);
                return this;
            }

            public MethodTraceInfo.Builder PeekMethod()
            {
                return _methodStack.Peek();
            }

            public MethodTraceInfo.Builder PopMethod()
            {
                return _methodStack.Pop();
            }
        }
    }
}
