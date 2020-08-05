using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int lu8Size => 1;
        public byte ReadByteslu8()
        {
            Enforce(lu8Size);
            return ReadByte();
        }
        public void WriteByteslu8(byte Value)
        {
            WriteByte(Value);
        }
    }
}
