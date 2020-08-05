namespace CSPDC
{
    public partial class ByteManager
    {
        public static int li8Size => 1;
        public byte ReadBytesli8()
        {
            Enforce(li8Size);
            return ReadByte();
        }
        public void WriteBytesli8(byte Value)
        {
            WriteByte(Value);
        }
    }
}
