using System.Buffers.Binary;

namespace CSPDC
{
    public struct f64 : IDataType
    {
        public static implicit operator f64(double value) => new f64(value);
        public static implicit operator double(f64 value) => value.Value;
        public double Value { get; set; }
        public int Size => 8;

        public f64(double value)
        {
            Value = value;
        }
        public unsafe void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            ulong r = BinaryPrimitives.ReadUInt64BigEndian(data);
            Value = *(double*)&r;
        }
        public unsafe void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            double w = Value;
            BinaryPrimitives.WriteUInt64BigEndian(data, *(ulong*)&w);
            bw.WriteBytes(data);
        }
    }
}
