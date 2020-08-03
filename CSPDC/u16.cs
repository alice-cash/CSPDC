using System.Buffers.Binary;

namespace CSPDC
{
    public struct u16 : IDataType
    {
        public static implicit operator u16(ushort value) => new u16(value);
        public static implicit operator ushort(u16 value) => value.Value;
        public ushort Value { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Size => 2;
        public u16(ushort value)
        {
            Value = value;
        }
        public void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            Value = BinaryPrimitives.ReadUInt16BigEndian(data);
        }
        public void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            BinaryPrimitives.WriteUInt16BigEndian(data, Value);
            bw.WriteBytes(data);
        }
    }
}
