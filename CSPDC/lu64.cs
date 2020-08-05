using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int lu64Size => 8;
        public ulong ReadByteslu64()
        {
            Enforce(lu64Size);
            byte[] data = ReadBytes(lu64Size);
            return BinaryPrimitives.ReadUInt64LittleEndian(data);
        }
        public void WriteByteslu64(ulong Value)
        {
            byte[] data = new byte[lu64Size];
            BinaryPrimitives.WriteUInt64LittleEndian(data, Value);
            WriteBytes(data);
        }
    }
}
