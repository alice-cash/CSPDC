using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace CSPDC.Generator
{
    public class SwitchBlockType : IBlockType
    {
        public string Name { get; }

        public string TypeName => "bool";

        private IBlockType CompareTo;

        private bool CompareToValueSet;

        private IDictionary<string,IBlockType> Fields;

        private IBlockType DefaultValue;

        public SwitchBlockType(string name, IBlockType compareTo, IBlockType defaultValue = null)
        {
            if (defaultValue == null) DefaultValue = new VoidBlockType();
            this.CompareTo = compareTo;
            this.Name = name;
            CompareToValueSet = false;
        }

        public void GenerateDeclareStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("public CSPDC.Module {0} { get; }", Name);
        }

        public void GenerateReadStatement(IndentedTextWriter tw)
        {
            if (CompareToValueSet)
            {

            }
            else
            {
                tw.WriteLine("switch(data.{0})", CompareTo.Name);
                tw.WriteLine("{");
                tw.Indent++;
                foreach (var field in Fields)
                {
                    tw.WriteLine("case {0}: {2} =  {1}.FromStream(bm); break;", field.Key, field.Value.TypeName, Name);
                }

                if(!(DefaultValue is VoidBlockType))
                {
                    tw.WriteLine("default: {1} = {0}.FromStream(bm); break;", DefaultValue.TypeName, Name);
                }

                tw.Indent--;
                tw.WriteLine("}");
            }
        }

        public void GenerateWriteStatement(IndentedTextWriter tw)
        {
            if (CompareToValueSet)
            {

            }
            else
            {
                tw.WriteLine("switch(data.{0})", CompareTo.Name);
                tw.WriteLine("{");
                tw.Indent++;
                foreach (var field in Fields)
                {
                    tw.WriteLine("case {0}: {1}.ToStream(bm, ({1}){2}); break;", field.Key, field.Value.TypeName, Name);
                }

                if (!(DefaultValue is VoidBlockType))
                {
                    tw.WriteLine("default: {1} = {0}.ToStream(bm, ({0}){1}); break;", DefaultValue.TypeName, Name);
                }

                tw.Indent--;
                tw.WriteLine("}");
            }
        }
    }
}
