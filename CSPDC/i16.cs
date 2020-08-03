using System.Buffers.Binary;

namespace CSPDC
{
    public struct i16 : IDataType
    {
        public static implicit operator i16(short value) => new i16(value);
        public static implicit operator short(i16 value) => value.Value;
        public short Value { get; set; }

        public int Size => 2;
        public i16(short value)
        {
            Value = value;
        }
        public void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            Value = BinaryPrimitives.ReadInt16BigEndian(data);
        }
        public void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            BinaryPrimitives.WriteInt16BigEndian(data, Value);
            bw.WriteBytes(data);
        }
    }
}
