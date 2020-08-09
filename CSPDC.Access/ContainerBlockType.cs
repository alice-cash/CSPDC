using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CSPDC.Generator
{
    public class ContainerBlockType : IBlockType
    {

        public Container Parent { get; }

        public string Name { get; }

        public string TypeName => Parent.Name;

        public ContainerBlockType(string name, Container parent)
        {
            Name = name;
            Parent = parent;
        }
        public void GenerateDeclareStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("public {0} {1} {{ get; set; }}", TypeName, Name);
        }

        public void GenerateReadStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("data.{0} = {1}.FromStream(bm);", Name, TypeName);
        }
        public void GenerateWriteStatement(IndentedTextWriter tw)
        {
            tw.WriteLine("{1}.ToStream(bm, data.{0});", Name, TypeName);
        }
    }
}
