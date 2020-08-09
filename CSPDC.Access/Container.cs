using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CSPDC.Generator
{
    public class Container : IModule
    {

        public List<IBlockType> Fields { get; set; }

        public BlockModule Parent { get; }

        public string Name { get; }

        public Container(BlockModule parent)
        {
            Name = parent.ModuleName;
            Parent = parent;
        }

        public void BuildModule(IndentedTextWriter tw)
        {
            foreach (var field in Fields)
                field.GenerateDeclareStatement(tw);

            tw.WriteLine("[System.CodeDom.Compiler.GeneratedCodeAttribute(\"{0}\",\"{1}\")]",
                Assembly.GetExecutingAssembly().GetName().Name,
                Assembly.GetExecutingAssembly().GetName().Version.ToString());

            tw.WriteLine("public static {0} FromStream(ByteManager bm)", Parent.ModuleName);
            tw.WriteLine("{");
            tw.Indent++;
            tw.WriteLine("{0} data = new {0}();", Parent.ModuleName);

            foreach (var field in Fields)
                field.GenerateReadStatement(tw);

            tw.WriteLine("return data;");


            tw.Indent--;
            tw.WriteLine("}");

            tw.WriteLine("[System.CodeDom.Compiler.GeneratedCodeAttribute(\"{0}\",\"{1}\")]",
    Assembly.GetExecutingAssembly().GetName().Name,
    Assembly.GetExecutingAssembly().GetName().Version.ToString());
            tw.WriteLine("public static void ToStream(ByteManager bm, {0} data)", Parent.ModuleName);
            tw.WriteLine("{");
            tw.Indent++;

            foreach (var field in Fields)
                field.GenerateWriteStatement(tw);

            tw.Indent--;
            tw.WriteLine("}");
        }

    }
}
