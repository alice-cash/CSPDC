using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace CSPDC.Generator
{
    public class Class : BlockModule
    {
        public override string ModuleType => "class";

        public override string ModuleAccessability => "public";
    }
}
