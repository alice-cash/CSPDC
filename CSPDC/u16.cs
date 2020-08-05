using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int u16Size => 2;
        public ushort ReadBytesu16()
        {
            Enforce(u16Size);
            byte[] data = ReadBytes(u16Size);
            return BinaryPrimitives.ReadUInt16BigEndian(data);
        }
        public void WriteBytes(ushort Value)
        {
            byte[] data = new byte[u16Size];
            BinaryPrimitives.WriteUInt16BigEndian(data, Value);
            WriteBytes(data);
        }
    }
}
