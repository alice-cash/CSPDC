using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int u64Size => 8;
        public ulong ReadBytesu64()
        {
            Enforce(u64Size);
            byte[] data = ReadBytes(u64Size);
            return BinaryPrimitives.ReadUInt64BigEndian(data);
        }
        public void WriteBytesu64(ulong Value)
        {
            byte[] data = new byte[u64Size];
            BinaryPrimitives.WriteUInt64BigEndian(data, Value);
            WriteBytes(data);
        }


    }
}
