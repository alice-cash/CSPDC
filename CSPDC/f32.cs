using System.Buffers.Binary;

namespace CSPDC
{
    public struct f32 : IDataType
    {
        public static implicit operator f32(float value) => new f32(value);
        public static implicit operator float(f32 value) => value.Value;
        public float Value { get; set; }
        public int Size => 4;
        public f32(float value)
        {
            Value = value;
        }
        public unsafe void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            uint r = BinaryPrimitives.ReadUInt32BigEndian(data);
            Value = *(float*)&r;
        }
        public unsafe void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            float w = Value;
            BinaryPrimitives.WriteUInt32BigEndian(data, *(uint*)&w);
            bw.WriteBytes(data);
        }
    }
}
