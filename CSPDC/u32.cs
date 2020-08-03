using System.Buffers.Binary;

namespace CSPDC
{
    public struct u32 : IDataType
    {
        public static implicit operator u32(uint value) => new u32(value);
        public static implicit operator uint(u32 value) => value.Value;
        
        public uint Value { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int Size => 4;
        public u32(uint value)
        {
            Value = value;
        }
        public void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            Value = BinaryPrimitives.ReadUInt32BigEndian(data);
        }
        public void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            BinaryPrimitives.WriteUInt32BigEndian(data, Value);
            bw.WriteBytes(data);
        }
    }
}
