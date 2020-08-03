using System.Buffers.Binary;

namespace CSPDC
{
    public struct li64 : IDataType
    {

        public long Value { get; set; }

        public int Size => 8;
        public li64(long value)
        {
            Value = value;
        }

        public void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            Value = BinaryPrimitives.ReadInt64LittleEndian(data);
        }
        public void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            BinaryPrimitives.WriteInt64LittleEndian(data, Value);
            bw.WriteBytes(data);
        }

        public static implicit operator li64(long value) => new li64(value);
        public static implicit operator long(li64 value) => value.Value;
    }
}
