using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int f32Size => 4;
        public unsafe float ReadBytesf32()
        {
            Enforce(f32Size);
            byte[] data = ReadBytes(f32Size);
            uint r = BinaryPrimitives.ReadUInt32BigEndian(data);
            return *(float*)&r;
        }
        public unsafe void WriteBytesf32(float Value)
        {
            byte[] data = new byte[f32Size];
            float w = Value;
            BinaryPrimitives.WriteUInt32BigEndian(data, *(uint*)&w);
            WriteBytes(data);
        }
    }
}
