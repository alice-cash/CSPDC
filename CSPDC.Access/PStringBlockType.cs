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

        public NativeBlockType countType;
        public bool countSet;
        public bool FixedCountType;
        public int FixedCount;
        public IBlockType LinkedCountType;

        public PStringBlockType(string Name, DataType countType)
        {
            this.Name = Name;
            this.countType = new NativeBlockType(countType, Name + "_Length");
            this.countSet = false;
        }

        public PStringBlockType(string Name, int FixedCount)
        {
            this.Name = Name;
            this.countSet = true;
            this.FixedCount = FixedCount;
            this.FixedCountType = true;
        }

        public PStringBlockType(string Name, IBlockType LinkedCountType)
        {
            this.Name = Name;
            this.countSet = true;
            this.LinkedCountType = LinkedCountType;
            this.FixedCountType = false;
        }

        public void GenerateDeclareStatement(IndentedTextWriter tw)
        {
            if (countSet)
            {

            }
            else
            {
            }
            tw.WriteLine("public {0} {1} {{ get; set; }}", TypeName, Name);
        }

        public void GenerateReadStatement(IndentedTextWriter tw)
        {
            if (countSet)
            {
                if (FixedCountType)
                {
                    tw.WriteLine("data.{0} = System.Text.Encoding.UTF8.GetString(bm.ReadBytes({1}));", Name, FixedCount);
                } else
                {

                }
                //    tw.WriteLine("data.{0} = bm.ReadBytes{1}();", Name, DataType);
            }
            else
            {
                tw.WriteLine("{0} {2}_Length = bm.ReadBytes{1}();", countType.TypeName, countType.DataType, Name);
                tw.WriteLine("data.{0} = System.Text.Encoding.UTF8.GetString(bm.ReadBytes({0}_Length));", Name);
            }
        }

        public void GenerateWriteStatement(IndentedTextWriter tw)
        {
            if (countSet)
            {
                if (FixedCountType)
                {
                    tw.WriteLine("byte[] {0}_data = System.Text.Encoding.UTF8.GetBytes(data.{0});", Name);
                    tw.WriteLine("byte[] {0}_final_data = new byte[{1}];", Name, FixedCount);
                    tw.WriteLine("System.Array.Copy({0}_data, {0}_final_data, {0}_data.Length > {1} ? {1} : {0}_data.Length);", Name, FixedCount);
                    tw.WriteLine("bm.WriteBytes({0}_final_data);", Name);

                }
                else
                {

                } 
                //      tw.WriteLine("data.{0} = bm.ReadBytes{1}();", Name, DataType);
            }
            else
            {
                tw.WriteLine("byte[] {0}_data = System.Text.Encoding.UTF8.GetBytes(data.{0});", Name);
                tw.WriteLine("{0} {1}_Length = {1}_data.Length;", countType.TypeName, Name);
                tw.WriteLine("bm.WriteBytes{1}({0}_Length);", Name, countType.DataType);
                tw.WriteLine("bm.WriteBytes({0}_data);", Name);
            }

        }
    }
}
