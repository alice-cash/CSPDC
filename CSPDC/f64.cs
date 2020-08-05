using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int f64Size => 8;
        public unsafe double ReadBytesf64()
        {
            Enforce(f64Size);
            byte[] data = ReadBytes(f64Size);
            ulong r = BinaryPrimitives.ReadUInt64BigEndian(data);
            return *(double*)&r;
        }
        public unsafe void WriteBytesf64(double Value)
        {
            byte[] data = new byte[f64Size];
            double w = Value;
            BinaryPrimitives.WriteUInt64BigEndian(data, *(ulong*)&w);
            WriteBytes(data);
        }
    }
}
