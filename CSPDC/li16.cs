using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int li16Size => 2;
        public short ReadBytesli16()
        {
            Enforce(li16Size);
            byte[] data = ReadBytes(li16Size);
            return BinaryPrimitives.ReadInt16LittleEndian(data);
        }
        public void WriteBytesli16(short Value)
        {
            byte[] data = new byte[li16Size];
            BinaryPrimitives.WriteInt16LittleEndian(data, Value);
            WriteBytes(data);
        }
    }
}
