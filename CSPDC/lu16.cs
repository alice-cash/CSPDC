using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int lu16Size => 2;

        public ushort ReadByteslu16()
        {
            Enforce(lu16Size);
            byte[] data = ReadBytes(lu16Size);
            return BinaryPrimitives.ReadUInt16LittleEndian(data);
        }
        public void WriteByteslu16(ushort Value)
        {
            byte[] data = new byte[lu16Size];
            BinaryPrimitives.WriteUInt16LittleEndian(data, Value);
            WriteBytes(data);
        }
    }
}
