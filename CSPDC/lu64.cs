using System.Buffers.Binary;

namespace CSPDC
{
    public struct lu64 : IDataType
    {


        public ulong Value { get; set; }

        public int Size => 8;
        public lu64(ulong value)
        {
            Value = value;
        }
        public void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            Value = BinaryPrimitives.ReadUInt64LittleEndian(data);
        }
        public void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            BinaryPrimitives.WriteUInt64LittleEndian(data, Value);
            bw.WriteBytes(data);
        }

        public static implicit operator lu64(ulong value) => new lu64(value);
        public static implicit operator ulong(lu64 value) => value.Value;
    }
}
