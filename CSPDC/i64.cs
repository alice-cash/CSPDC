using System.Buffers.Binary;

namespace CSPDC
{
    public struct i64 : IDataType
    {
        public static implicit operator i64(long value) => new i64(value);
        public static implicit operator long(i64 value) => value.Value;
        public long Value { get; set; }
        public int Size => 8;
        public i64(long value)
        {
            Value = value;
        }
        public void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            Value = BinaryPrimitives.ReadInt64BigEndian(data);
        }
        public void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            BinaryPrimitives.WriteInt64BigEndian(data, Value);
            bw.WriteBytes(data);
        }

    }
}
