using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace CSPDC.Generator
{
    class VoidBlockType : IBlockType
    {
        public string Name { get; }

        public string TypeName => "void";

        public void GenerateDeclareStatement(IndentedTextWriter tw)
        {
        }

        public void GenerateReadStatement(IndentedTextWriter tw)
        {
        }

        public void GenerateWriteStatement(IndentedTextWriter tw)
        {
        }
    }
}
