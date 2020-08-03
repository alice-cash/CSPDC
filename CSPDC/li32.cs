using System.Buffers.Binary;

namespace CSPDC
{
    public struct li32 : IDataType
    {
        public static implicit operator li32(int value) => new li32(value);
        public static implicit operator int(li32 value) => value.Value;
        public int Value { get; set; }

        public int Size => 4;
        public li32(int value)
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
