using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace CSPDC.Generator
{
    public class PStringBlockType : IBlockType
    {
        public string Name { get; }

        public string TypeName => "string";

        private BufferBlockType _buffer;

        public PStringBlockType(string Name, DataType countType)
        {
            _buffer = new BufferBlockType(Name + "_buffer", countType);
        }

        public PStringBlockType(string Name, int FixedCount)
        {
            this.Name = Name;
            _buffer = new BufferBlockType(Name + "_buffer", FixedCount);

        }

        public PStringBlockType(string Name, IBlockType LinkedCountType)
        {
            this.Name = Name;
            _buffer = new BufferBlockType(Name + "_buffer", LinkedCountType);

        }

        public void GenerateDeclareStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("public {0} {1} {{ get; set; }}", TypeName, Name);
            _buffer.GenerateDeclareStatement(tw);
        }

        public void GenerateReadStatement(IndentedTextWriter tw)
        {
            _buffer.GenerateReadStatement(tw);
            tw.WriteLine("data.{0} = System.Text.Encoding.UTF8.GetString(data.{1});", Name, _buffer.Name);
        }

        public void GenerateWriteStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("data.{1} = System.Text.Encoding.UTF8.GetBytes(data.{0});", Name, _buffer.Name);
            _buffer.GenerateWriteStatement(tw);
        }
    }
}
