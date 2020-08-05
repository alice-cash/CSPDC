using System.CodeDom.Compiler;
using System.IO;
using System.Text;

namespace CSPDC.Generator
{
    public interface IModule
    {
        public abstract void BuildModule(IndentedTextWriter tw);

    }
}