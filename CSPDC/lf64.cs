using System.Buffers.Binary;

namespace CSPDC
{
    public struct lf64 : IDataType
    {
        public static implicit operator lf64(double value) => new lf64(value);
        public static implicit operator double(lf64 value) => value.Value;
        public double Value { get; set; }
        public int Size => 4;
        public lf64(double value)
        {
            Value = value;
        }
        public unsafe void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            ulong r = BinaryPrimitives.ReadUInt64LittleEndian(data);
            Value = *(double*)&r;
        }
        public unsafe void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            double w = Value;
            BinaryPrimitives.WriteUInt64LittleEndian(data, *(ulong*)&w);
            bw.WriteBytes(data);
        }
    }
}
