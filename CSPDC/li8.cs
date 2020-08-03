namespace CSPDC
{
    public struct li8 : IDataType
    {
        public static implicit operator li8(byte value) => new li8(value);
        public static implicit operator byte(li8 value) => value.Value;

        public byte Value { get; set; }
        public int Size => 1;
        public li8(byte value)
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
