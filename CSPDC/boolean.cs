namespace CSPDC
{
    public struct boolean : IDataType
    {
        public bool Value { get; set; }

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
