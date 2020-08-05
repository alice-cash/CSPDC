namespace CSPDC
{
    public partial class ByteManager
    {
        public static int u8Size => 1;
        public byte ReadBytesu8()
        {
            Enforce(u8Size);
            return ReadByte();
        }
        public void WriteBytesu8(byte Value)
        {
            WriteByte(Value);
        }
    }
}
