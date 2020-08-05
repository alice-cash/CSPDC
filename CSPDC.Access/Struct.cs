using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom.Compiler;

namespace CSPDC.Generator
{
    public class Struct : BlockModule
    {
        public override string ModuleType => "struct";
        public override string ModuleAccessability => "public";
    }
}
