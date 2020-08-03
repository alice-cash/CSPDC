namespace CSPDC
{
    public struct u8 : IDataType
    {

        public byte Value { get; set; }

        public int Size => 1;
        public u8(byte value)
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

        public static implicit operator u8(byte value) => new u8(value);
        public static implicit operator byte(u8 value) => value.Value;
    }
}
