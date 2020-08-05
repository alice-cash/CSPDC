using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int lu32Size => 4;
        public uint ReadByteslu32()
        {
            Enforce(lu32Size);
            byte[] data = ReadBytes(lu32Size);
            return BinaryPrimitives.ReadUInt32LittleEndian(data);
        }
        public void WriteByteslu32(uint Value)
        {
            byte[] data = new byte[lu32Size];
            BinaryPrimitives.WriteUInt32LittleEndian(data, Value);
            WriteBytes(data);
        }
    }
}
