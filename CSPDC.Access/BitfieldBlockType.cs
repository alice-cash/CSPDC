using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSPDC.Generator
{
    public class BitfieldBlockType : IBlockType
    {
        public string Name { get; }

        public string TypeName { get; }


        private DataType sizeType;
        private int size;
        private bool signed;

        private BitfieldField[] fields;

        public BitfieldBlockType(string Name, IList<BitfieldField> fields)
        {
            this.Name = Name;
            this.fields = fields.ToArray();
            foreach (var field in fields)
                signed |= field.Signed;

            foreach (var field in fields)
                size += field.Size;

            if (signed)
                if (size != 8 && size != 16 && size != 32 && size != 64)
                    throw new Exception("bitfield not alligned");

            if (size <= 8) sizeType = DataType.u8;
            else if (size <= 16) sizeType = DataType.u16;
            else if (size <= 32) sizeType = DataType.u32;
            else if (size <= 64) sizeType = DataType.u64;
            else throw new Exception("bitfield larger than 64 bytes");


        }

        public void GenerateDeclareStatement(IndentedTextWriter tw)
        {
            foreach (var field in fields)
                tw.WriteLine("public {0} {1} {{ get; set; }}", NativeBlockType.GetDataTypeString(field.Type), field.Name);

        }

        public void GenerateReadStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("{0} {1}_data;", NativeBlockType.GetDataTypeString(sizeType), Name);
            tw.WriteLine("{0}_data = bm.ReadBytes{1}();", Name, sizeType);

            foreach (var field in fields.Reverse())
            {
                tw.WriteLine("data.{0} = ({3})({1}_data & {2});", field.Name, Name, genBitmask(field.Size), NativeBlockType.GetDataTypeString(field.Type));
                tw.WriteLine("{0}_data >>= {1};", Name, field.Size);
            }

        }


        public void GenerateWriteStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("{0} {1}_data = 0;", NativeBlockType.GetDataTypeString(sizeType), Name);
            foreach (var field in fields)
            {
                tw.WriteLine("{1}_data |= ({3})(data.{0} & {2});", field.Name, Name, genBitmask(field.Size), NativeBlockType.GetDataTypeString(sizeType));
                tw.WriteLine("{0}_data <<= {1};", Name, field.Size);
            }
            tw.WriteLine("bm.WriteBytes{1}({0}_data);", Name, sizeType);

        }


        private string genBitmask(int length)
        {
            int totlen = 0;
            if (length <= 8) totlen = 8;
            else if (length <= 16) totlen = 16;
            else if (length <= 32) totlen = 32;
            else if (length <= 64) totlen = 64;
            string result = "0b";
            for (int i = 0; i < totlen - length; i++)
                result += "0";
            for (int i = 0; i < length; i++)
                result += "1";
            return result;
        }
    }
}
