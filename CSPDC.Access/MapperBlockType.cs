using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace CSPDC.Generator
{
    class MapperBlockType : IBlockType
    {
        public string Name { get; }

        public NativeBlockType FieldType { get; }

        public DataType Type { get { return FieldType.DataType; } }
        public string TypeName => NativeBlockType.GetDataTypeString(Type);
        public Dictionary<string,string> MapperArray { get; set; }

        public MapperBlockType(string name, NativeBlockType type, Dictionary<string,string> data = null)
        {
            this.Name = name;
            if (data == null) data = new Dictionary<string, string>();
            this.MapperArray = data;
            this.FieldType = type;
        }

        public void GenerateDeclareStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("public enum {0} : {1}", TypeName, Name);
            tw.WriteLine("{");
            tw.Indent++;
            foreach (var item in MapperArray)
                tw.WriteLine("{0} = {1},", item.Key, item.Value);

            tw.Indent--;
            tw.WriteLine("}");

            tw.WriteLine("public {0} {1}_MapperFunction({0} type)", TypeName, Name);
            tw.WriteLine("{");
            tw.Indent++;
            if (MapperArray.Count > 0)
            {
                foreach(var item in MapperArray)
                    tw.WriteLine("if(type == \"{0}\") return {1}", item.Key, item.Value);
            }
            tw.Indent--;
            tw.WriteLine("}");
        }

        public void GenerateReadStatement(IndentedTextWriter tw)
        {
        }

        public void GenerateWriteStatement(IndentedTextWriter tw)
        {
        }
    }
}
