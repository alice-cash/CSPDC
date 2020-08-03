namespace CSPDC
{
    public struct buffer : IDataType
    {

        public byte[] Value { get; set; }

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
