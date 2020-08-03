using System.Buffers.Binary;

namespace CSPDC
{
    public struct lu32 : IDataType
    {
        public static implicit operator lu32(int value) => new lu32(value);
        public static implicit operator int(lu32 value) => value.Value;

        public int Value { get; set; }

        public int Size => 4;
        public lu32(int value)
        {
            Value = value;
        }
        public void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            Value = BinaryPrimitives.ReadInt32LittleEndian(data);
        }
        public void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            BinaryPrimitives.WriteInt32LittleEndian(data, Value);
            bw.WriteBytes(data);
        }
    }
}
