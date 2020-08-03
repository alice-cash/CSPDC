using System.Buffers.Binary;

namespace CSPDC
{
    public struct lu8 : IDataType
    {
        public static implicit operator lu8(byte value) => new lu8(value);
        public static implicit operator byte(lu8 value) => value.Value;
        public byte Value { get; set; }

        public int Size => 1;
        public lu8(byte value)
        {
            Value = value;
        }
        public void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            Value = br.ReadByte();
        }
        public void WriteBytes(ByteWriter bw)
        {
            bw.WriteByte(Value);
        }


    }
}
