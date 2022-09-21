using System.Reflection;
using System.Text;
using Tracer.Core;
using Tracer.Serialization.Abstraction;

internal class Program
{
    private static ITracer _tracer = new Tracer.Core.Tracer();


    private static void Main(string[] args)
    {
        Assembly jsonAssembly = Assembly.Load("Json");
        Assembly xmlAssembly = Assembly.Load("Xml");
        Assembly yamlAssembly = Assembly.Load("Yaml");

        var jsonSerializer = (ITraceResultSerializer)jsonAssembly.CreateInstance("Tracer.Json.JsonTraceResultSerializer");
        var xmlSerializer = (ITraceResultSerializer)xmlAssembly.CreateInstance("Tracer.Xml.XmlTraceResultSerializer");
        var yamlSerializer = (ITraceResultSerializer)yamlAssembly.CreateInstance("Tracer.Yaml.YamlTraceResultSerializer");

        Thread thread = new Thread(Method_4);
        thread.Start();
        Method_1();

        var result = _tracer.GetTraceResult();
        string separator = string.Concat(Environment.NewLine, Environment.NewLine);
        byte[] separatorBytes = Encoding.UTF8.GetBytes(separator);

        using (var s = new MemoryStream())
        {
            jsonSerializer.Serialize(result, s);
            s.Write(separatorBytes, 0, separator.Length);
            xmlSerializer.Serialize(result, s);
            s.Write(separatorBytes, 0, separator.Length);
            yamlSerializer.Serialize(result, s);
            Console.WriteLine(Encoding.UTF8.GetString(s.ToArray()));
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void Method_1()
    {
        _tracer.StartTrace();
        Method_2();
        Method_4();
        Thread.Sleep(200);
        _tracer.StopTrace();
    }

    private static void Method_2()
    {
        _tracer.StartTrace();
        Method_3();
        Thread.Sleep(100);
        _tracer.StopTrace();
    }

    private static void Method_3()
    {
        _tracer.StartTrace();
        Thread.Sleep(250);
        _tracer.StopTrace();
    }

    private static void Method_4()
    {
        _tracer.StartTrace();
        Method_5();
        Thread.Sleep(500);
        _tracer.StopTrace();
    }

    private static void Method_5()
    {
        _tracer.StartTrace();
        Thread.Sleep(150);
        _tracer.StopTrace();
    }
}