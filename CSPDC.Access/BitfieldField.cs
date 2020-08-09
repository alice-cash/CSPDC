using System.CodeDom.Compiler;

namespace CSPDC.Generator
{
    public class BitfieldField : IBlockType
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public bool Signed { get; set; }

        public DataType Type
        {
            get
            {
                if (Size <= 8) return DataType.u8;
                else if (Size <= 16) return DataType.u16;
                else if (Size <= 32) return DataType.u32;
                else if (Size <= 64) return DataType.u64;
                throw new System.Exception("Size too big!");
            }
        }

        public string TypeName => NativeBlockType.GetDataTypeString(Type);

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