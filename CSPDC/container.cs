using System.Collections.Generic;

namespace CSPDC
{
    public struct container : IDataType
    {

        public IDictionary<string,IDataType> Value { get; set; }

        public void ReadBytes(ByteReader br)
        {
            throw new System.NotImplementedException();
        }

        public void WriteBytes(ByteWriter bw)
        {
            throw new System.NotImplementedException();
        }
    }
}
