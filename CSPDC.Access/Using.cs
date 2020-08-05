using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace CSPDC.Generator
{
    public class Usinge : IModule
    {
        public List<string> UsingStatements { get; set; }

        public void BuildModule(IndentedTextWriter tw)
        {
            foreach (var statment in UsingStatements)
                tw.WriteLine("using {0};\n", UsingStatements);

        }
    }
}
