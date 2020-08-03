using System.Buffers.Binary;

namespace CSPDC
{
    public struct li16 : IDataType
    {
        public static implicit operator li16(short value) => new li16(value);
        public static implicit operator short(li16 value) => value.Value;
        public short Value { get; set; }

        public int Size => 2;
        public li16(short value)
        {
            Value = value;
        }

        public void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            Value = BinaryPrimitives.ReadInt16LittleEndian(data);
        }
        public void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            BinaryPrimitives.WriteInt16LittleEndian(data, Value);
            bw.WriteBytes(data);
        }
    }
}
