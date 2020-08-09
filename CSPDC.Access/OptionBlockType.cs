using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace CSPDC.Generator
{
    public class OptionBlockType : IBlockType
    {
        public string Name { get; }

        public string TypeName => "bool";

        private IBlockType UnderlyingType;

        public OptionBlockType(IBlockType UnderlyingType)
        {
            this.Name = UnderlyingType.Name + "_IsSet";
            this.UnderlyingType = UnderlyingType;

        }

        public void GenerateDeclareStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("public {0} {1} {{ get; set; }}", TypeName, Name);
            UnderlyingType.GenerateDeclareStatement(tw);
        }

        public void GenerateReadStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("if(data.{0})", Name);
            tw.WriteLine("{");
            tw.Indent++;
            UnderlyingType.GenerateReadStatement(tw);
            tw.Indent--; 
            tw.WriteLine("}");
        }

        public void GenerateWriteStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("if(data.{0})", Name);
            tw.WriteLine("{");
            tw.Indent++;
            UnderlyingType.GenerateWriteStatement(tw);
            tw.Indent--;
            tw.WriteLine("}");
        }
    }
}
