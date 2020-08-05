using CSPDC.Generator;
using System;
using System.Collections.Generic;

namespace CSPDC.Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            ModuleBuilder mb = new ModuleBuilder();

            var c = new System.Collections.Generic.List<IModule>();
            var d = new System.Collections.Generic.List<IModule>();
            var f = new Dictionary<string, DataType>();
            f.Add("Apples", DataType.varint);
            f.Add("Pears", DataType.varint);
            f.Add("Bears", DataType.varint);
            var o = new Struct() { ModuleName = "BlaBla", Children = d };
            d.Add(new Container(o) { Fields = f });
            c.Add(o);
            mb.Module = new Namespace() { ModuleName = "Test", Children = c };
            Console.WriteLine(mb.Build());
        }
    }
}
