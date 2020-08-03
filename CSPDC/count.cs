namespace CSPDC
{
    public struct count : IDataType
    {
        public short Value { get; set; }

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
