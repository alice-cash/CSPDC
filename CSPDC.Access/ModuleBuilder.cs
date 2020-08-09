using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSPDC.Generator
{
    public class ModuleBuilder
    {
        public IModule Module { get; set; }
        public string Indent { get; set; }
        public List<string> UsingStatements { get; set; }

        public ModuleBuilder()
        {
            Indent = "    ";
            UsingStatements = new List<string>();
        }

        public string Build()
        {
            StringWriter sw = new StringWriter();
            IndentedTextWriter tw = new IndentedTextWriter(sw, Indent);

            foreach (var statment in UsingStatements)
                tw.WriteLine("using {0};\n", statment);

            Module.BuildModule(tw);
            return sw.ToString();
        }
    }
}
