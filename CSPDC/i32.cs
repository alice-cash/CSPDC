using System.Buffers.Binary;

namespace CSPDC
{
    public struct i32 : IDataType
    { 
        public static implicit operator i32(int value) => new i32(value);
        public static implicit operator int(i32 value) => value.Value;
        public int Value { get; set; }

        public int Size => 4;

        public i32(int value)
        {
            Value = value;
        }
        public void ReadBytes(ByteReader br)
        {
            br.Enforce(Size);
            byte[] data = br.ReadBytes(Size);
            Value = BinaryPrimitives.ReadInt32BigEndian(data);
        }
        public void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[Size];
            BinaryPrimitives.WriteInt32BigEndian(data, Value);
            bw.WriteBytes(data);
        }
    }
}
