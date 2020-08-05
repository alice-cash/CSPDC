using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {

        public static int i64Size => 8;

        public long ReadBytesi64()
        {
            Enforce(i64Size);
            byte[] data = ReadBytes(i64Size);
            return BinaryPrimitives.ReadInt64BigEndian(data);
        }
        public void WriteBytesi64(long Value)
        {
            byte[] data = new byte[i64Size];
            BinaryPrimitives.WriteInt64BigEndian(data, Value);
            WriteBytes(data);
        }

    }
}
