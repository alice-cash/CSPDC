namespace CSPDC
{
    public struct i8 : IDataType
    {
        public static implicit operator i8(byte value) => new i8(value);
        public static implicit operator byte(i8 value) => value.Value;
        public byte Value { get; set; }
        public int Size => 1;
        public i8(byte value)
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
