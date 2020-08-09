using System.CodeDom.Compiler;

namespace CSPDC.Generator
{
    public interface IBlockType
    {
        public string Name { get; }
        public string TypeName { get; }

        public void GenerateReadStatement(IndentedTextWriter tw);
        public void GenerateWriteStatement(IndentedTextWriter tw);
        void GenerateDeclareStatement(IndentedTextWriter tw);
    }
}