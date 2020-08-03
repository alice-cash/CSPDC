using System.Buffers.Binary;

namespace CSPDC
{
    public struct u64 : IDataType
    {
        public static implicit operator u64(ulong value) => new u64(value);
        public static implicit operator ulong(u64 value) => value.Value;
        public ulong Value { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Size => 8;
        public u64(ulong value)
        {
            Value = value;
        }

        public void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            Value = BinaryPrimitives.ReadUInt64BigEndian(data);
        }
        public void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            BinaryPrimitives.WriteUInt64BigEndian(data, Value);
            bw.WriteBytes(data);
        }


    }
}
