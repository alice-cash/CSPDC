namespace CSPDC
{
    public partial class ByteManager
    {
        public static int i8Size => 1;
        public sbyte ReadBytes()
        {
            Enforce(i8Size);
            return (sbyte)ReadByte();
        }
        public void WriteBytes(sbyte data)
        {
            WriteByte((byte)data);
        }
    }
}
