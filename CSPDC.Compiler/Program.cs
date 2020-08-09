using CSPDC.Generator;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CSPDC.Compiler
{
    class Program
    {
        static void Main(string[] args)
        {
            ModuleBuilder mb = new ModuleBuilder();

            var c = new System.Collections.Generic.List<IModule>();
            var d = new System.Collections.Generic.List<IModule>();
            var f = new List<IBlockType>();
            /*
            f.Add(new NativeBlockType(DataType.boolean, "Apple"));
            f.Add(new NativeBlockType(DataType.cstring, "Bear"));
            f.Add(new NativeBlockType(DataType.u32, "Crab"));

            f.Add(new PStringBlockType("TEST", DataType.varint));
            f.Add(new PStringBlockType("T232", 5));*/
            BitfieldField[] bitfielddata = { new BitfieldField() { Name = "A1", Size = 1, Signed = true },
                new BitfieldField(){ Name = "A2", Size = 2, Signed = true },
                new BitfieldField(){ Name = "A3", Size = 4, Signed = true },
                new BitfieldField(){ Name = "A4", Size = 8, Signed = true },
            new BitfieldField() { Name = "A5", Size = 1+16, Signed = true } };

        f.Add(new BitfieldBlockType("TEE", bitfielddata));

            var o = new Struct() { ModuleName = "BlaBla", Children = d };
            d.Add(new Container(o) { Fields = f });
            c.Add(o);
            mb.Module = new Namespace() { ModuleName = "Test", Children = c };
            mb.UsingStatements.Add("CSPDC");
            Console.WriteLine(mb.Build());
        }
    }
}
