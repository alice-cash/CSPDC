using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSPDC.Generator
{
    public class Namespace : BlockModule
    {
        public override string ModuleType => "namespace";

        public override string ModuleAccessability => "";
    }
}
