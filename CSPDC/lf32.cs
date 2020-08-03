using System.Buffers.Binary;

namespace CSPDC
{
    public struct lf32 : IDataType
    {

        public static implicit operator lf32(float value) => new lf32(value);
        public static implicit operator float(lf32 value) => value.Value;
        public float Value { get; set; }
        public int Size => 4;
        public lf32(float value)
        {
            Value = value;
        }
        public unsafe void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            uint r = BinaryPrimitives.ReadUInt32LittleEndian(data);
            Value = *(float*)&r;
        }
        public unsafe void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            float w = Value;
            BinaryPrimitives.WriteUInt32LittleEndian(data, *(uint*)&w);
            bw.WriteBytes(data);
        }
    }
}
