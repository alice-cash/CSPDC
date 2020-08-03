using System.Collections.Generic;

namespace CSPDC
{
    public struct bitfield : IDataType
    {
        public IList<bitfield_paramater> Value { get; set; }

        public struct bitfield_paramater
        {
            int size;
            string name;
            bool signed;
        }

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
