using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int u32Size => 4;
        public uint ReadBytesu32()
        {
            Enforce(u32Size);
            byte[] data = ReadBytes(u32Size);
            return BinaryPrimitives.ReadUInt32BigEndian(data);
        }
        public void WriteBytes(uint Value)
        {
            byte[] data = new byte[u32Size];
            BinaryPrimitives.WriteUInt32BigEndian(data, Value);
            WriteBytes(data);
        }
    }
}
