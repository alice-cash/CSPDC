namespace CSPDC
{
    public partial class ByteManager
    {
        public static int i8Size => 1;
        public sbyte ReadBytesi8()
        {
            Enforce(i8Size);
            return (sbyte)ReadByte();
        }
        public void WriteBytesi8(sbyte data)
        {
            WriteByte((byte)data);
        }
    }
}
