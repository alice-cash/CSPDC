using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSPDC.Generator
{
    public class Container: IModule
    {

        public IDictionary<string, DataType> Fields { get; set; }

        public BlockModule Parent { get; }

        public Container(BlockModule parent)
        {
            Parent = parent;
        }

        public void BuildModule(IndentedTextWriter tw)
        {
            foreach(var field in Fields)
                tw.WriteLine("public {0} {1} {{ get; set; }}", GetDataTypeString(field.Value), field.Key);

            tw.WriteLine("public static {0} FromStream(ByteReader br)", Parent.ModuleName);
            tw.WriteLine("{");
            tw.Indent++;

            foreach (var field in Fields)
                tw.WriteLine("this.{0} = br.Read", GetDataTypeString(field.Value), field.Key);

            tw.Indent--;
            tw.WriteLine("}");
            tw.WriteLine("public void ToStream(ByteWriter br)", Parent.ModuleName);
            tw.WriteLine("{");
            tw.Indent++;

            tw.Indent--;
            tw.WriteLine("}");
        }

        private string GetDataTypeString(DataType type)
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

                case DataType.pstring:
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
