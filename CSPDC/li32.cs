using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int li32Size => 4;
        public int ReadBytesli32()
        {
            Enforce(li32Size);
            byte[] data = ReadBytes(li32Size);
            return BinaryPrimitives.ReadInt32LittleEndian(data);
        }
        public void WriteBytesli32(int Value)
        {
            byte[] data = new byte[li32Size];
            BinaryPrimitives.WriteInt32LittleEndian(data, Value);
            WriteBytes(data);
        }
    }
}
