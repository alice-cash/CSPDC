using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int i32Size => 4;

        public int ReadBytesi32()
        {
            Enforce(i32Size);
            byte[] data = ReadBytes(i32Size);
            return BinaryPrimitives.ReadInt32BigEndian(data);
        }
        public void WriteBytes(int Value)
        {
            byte[] data = new byte[i32Size];
            BinaryPrimitives.WriteInt32BigEndian(data, Value);
            WriteBytes(data);
        }
    }
}
