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

        public ModuleBuilder()
        {
            Indent = "    ";
        }

        public string Build()
        {
            StringWriter sw = new StringWriter();
            IndentedTextWriter writer = new IndentedTextWriter(sw, Indent);
            Module.BuildModule(writer);
            return sw.ToString();
        }
    }
}
