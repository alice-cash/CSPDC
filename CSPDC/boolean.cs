namespace CSPDC
{
    public partial class ByteManager
    {
        public static int booleanSize => 1;
        public bool ReadBytesboolean()
        {
            Enforce(booleanSize);
            return ReadByte() != 0;
        }
        public void WriteBytesboolean(bool Value)
        {
            WriteByte(Value ? (byte)1 : (byte)0);
        }
    }
}
