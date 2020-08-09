using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace CSPDC.Generator
{
    public class BufferBlockType : IBlockType
    {
        public string Name { get; }

        public string TypeName => "byte[]";

        public NativeBlockType countType;
        public bool countSet;
        public bool FixedCountType;
        public int FixedCount;
        public IBlockType LinkedCountType;

        public BufferBlockType(string Name, DataType countType)
        {
            this.Name = Name;
            this.countType = new NativeBlockType(countType, Name + "_Length");
            this.countSet = false;
        }

        public BufferBlockType(string Name, int FixedCount)
        {
            this.Name = Name;
            this.countSet = true;
            this.FixedCount = FixedCount;
            this.FixedCountType = true;
        }

        public BufferBlockType(string Name, IBlockType LinkedCountType)
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
                    tw.WriteLine("data.{0} = bm.ReadBytes({1});", Name, FixedCount);
                } else
                {
                    tw.WriteLine("data.{0} = bm.ReadBytes(data.{1});", Name, LinkedCountType.Name);
                }
            }
            else
            {
                tw.WriteLine("{0} {2}_Length = bm.ReadBytes{1}();", countType.TypeName, countType.DataType, Name);
                tw.WriteLine("data.{0} = bm.ReadBytes({0}_Length);", Name);
            }
        }

        public void GenerateWriteStatement(IndentedTextWriter tw)
        {
            if (countSet)
            {
                if (FixedCountType)
                {
                    //tw.WriteLine("byte[] {0}_data = data.{0};", Name);
                    tw.WriteLine("byte[] {0}_data = new byte[{1}];", Name, FixedCount);
                    tw.WriteLine("System.Array.Copy({0}, {0}_data, {0}.Length > {1} ? {1} : {0}.Length);", Name, FixedCount);
                    tw.WriteLine("bm.WriteBytes({0}_data);", Name);
                }
                else
                {
                    //tw.WriteLine("byte[] {0}_data = data.{0};", Name);
                    tw.WriteLine("byte[] {0}_data = new byte[data.{1}];", Name, LinkedCountType.Name);
                    tw.WriteLine("System.Array.Copy({0}, {0}_data, {0}.Length > data.{1} ? data.{1} : {0}.Length);", Name, LinkedCountType.Name);
                    tw.WriteLine("bm.WriteBytes({0}_data);", Name);
                } 
                //      tw.WriteLine("data.{0} = bm.ReadBytes{1}();", Name, DataType);
            }
            else
            {
                tw.WriteLine("{0} {1}_Length = {1}.Length;", countType.TypeName, Name);
                tw.WriteLine("bm.WriteBytes{1}({0}_Length);", Name, countType.DataType);
                tw.WriteLine("bm.WriteBytes({0});", Name);
            }

        }
    }
}
