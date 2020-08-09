using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace CSPDC.Generator
{
    public class NativeBlockType : IBlockType
    {
        public DataType DataType { get; }
        public string Name { get; }
        public string TypeName { get { return GetDataTypeString(DataType); } }


        public NativeBlockType(DataType type, string name)
        {
            DataType = type;
            Name = name;
        }
        public void GenerateDeclareStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("public {0} {1} {{ get; set; }}", TypeName, Name);
        }

        public void GenerateReadStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("data.{0} = bm.ReadBytes{1}();", Name, DataType);
        }
        public void GenerateWriteStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("bm.WriteBytes{1}(data.{0});", Name, DataType);
        }

        public static string GetDataTypeString(DataType type)
        {
            switch (type)
            {
                case DataType.i8:
                case DataType.u8:
                case DataType.li8:
                case DataType.lu8:
                    return "byte";

                case DataType.i16:
                case DataType.li16:
                    return "short";

                case DataType.u16:
                case DataType.lu16:
                    return "ushort";

                case DataType.i32:
                case DataType.li32:
                case DataType.varint:
                    return "int";

                case DataType.u32:
                case DataType.lu32:
                    return "uint";

                case DataType.i64:
                case DataType.li64:
                    return "long";

                case DataType.u64:
                case DataType.lu64:
                    return "ulong";

                case DataType.cstring:
                    return "string";

                case DataType.boolean:
                    return "bool";

                case DataType.buffer:
                    return "byte[]";

            }

            throw new System.ComponentModel.InvalidEnumArgumentException();
        }
    }
}
