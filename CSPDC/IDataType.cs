using System;
using System.Collections.Generic;
using System.Text;

namespace CSPDC
{
    public interface IDataType
    {
        public void ReadBytes(ByteReader br);

        public void WriteBytes(ByteWriter bw);
    }
}
