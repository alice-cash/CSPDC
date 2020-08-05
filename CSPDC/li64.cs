using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int li64Size => 8;
        public long ReadBytesli64()
        {
            Enforce(li64Size);
            byte[] data = ReadBytes(li64Size);
            return BinaryPrimitives.ReadInt64LittleEndian(data);
        }
        public void WriteBytesli64(long Value)
        {
            byte[] data = new byte[li64Size];
            BinaryPrimitives.WriteInt64LittleEndian(data, Value);
            WriteBytes(data);
        }
    }
}
