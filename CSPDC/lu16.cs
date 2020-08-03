using System.Buffers.Binary;

namespace CSPDC
{
    public struct lu16 : IDataType
    {
        public static implicit operator lu16(ushort value) => new lu16(value);
        public static implicit operator ushort(lu16 value) => value.Value;
        public ushort Value { get; set; }

        public int Size => 2;
        public lu16(ushort value)
        {
            Value = value;
        }
        public void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            Value = BinaryPrimitives.ReadUInt16LittleEndian(data);
        }
        public void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            BinaryPrimitives.WriteUInt16LittleEndian(data, Value);
            bw.WriteBytes(data);
        }
    }
}
