using System.Collections;

namespace CSPDC
{
    public struct array : IDataType
    {
        public IEnumerable Value { get; set; }

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
