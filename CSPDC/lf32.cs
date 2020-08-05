using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int lf32Size => 4;
        public unsafe float ReadByteslf32()
        {
            Enforce(lf32Size);
            byte[] data = ReadBytes(lf32Size);
            uint r = BinaryPrimitives.ReadUInt32LittleEndian(data);
            return *(float*)&r;
        }
        public unsafe void WriteByteslf32(float Value)
        {
            byte[] data = new byte[lf32Size];
            float w = Value;
            BinaryPrimitives.WriteUInt32LittleEndian(data, *(uint*)&w);
            WriteBytes(data);
        }
    }
}
