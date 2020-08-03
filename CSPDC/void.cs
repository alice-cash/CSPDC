namespace CSPDC
{
    public struct @void : IDataType
    {
        public VoidObject Value { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void ReadBytes(ByteReader br)
        {
            throw new System.NotImplementedException();
        }
        public void WriteBytes(ByteWriter bw)
        {
            throw new System.NotImplementedException();
        }
    }

    public class VoidObject { }
}
