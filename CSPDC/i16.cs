using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {

        public static int i16Size => 2;
        public short ReadBytesi16()
        {
            Enforce(i16Size);
            byte[] data = ReadBytes(i16Size);
            return BinaryPrimitives.ReadInt16BigEndian(data);
        }
        public void WriteBytesi16(short Value)
        {
            byte[] data = new byte[i16Size];
            BinaryPrimitives.WriteInt16BigEndian(data, Value);
            WriteBytes(data);
        }
    }
}
