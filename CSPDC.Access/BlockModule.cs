using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSPDC.Generator
{
    public abstract class BlockModule : IModule
    {

        public abstract string ModuleType { get; }
        public string ModuleName { get; set; }
        public abstract string ModuleAccessability { get; }
        public abstract bool GeneratedCodeAttribute { get; }
        public List<IModule> Children { get; set; }
        public void BuildModule(IndentedTextWriter tw)
        {

            if(GeneratedCodeAttribute)
            tw.WriteLine("[System.CodeDom.Compiler.GeneratedCodeAttribute(\"{0}\",\"{1}\")]",
                Assembly.GetExecutingAssembly().GetName().Name,
                Assembly.GetExecutingAssembly().GetName().Version.ToString());

            if (ModuleAccessability != "")
                tw.Write("{0} ", ModuleAccessability);

            tw.WriteLine("{0} {1}", ModuleType, ModuleName);
            tw.WriteLine("{");
            tw.Indent++;
            foreach (var child in Children)
                child.BuildModule(tw);
            tw.Indent--;
            tw.WriteLine("}");
        }
    }
}
