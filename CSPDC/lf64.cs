using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public static int lf64Size => 4;
        public unsafe double ReadByteslf16()
        {
            Enforce(lf64Size);
            byte[] data = ReadBytes(lf64Size);
            ulong r = BinaryPrimitives.ReadUInt64LittleEndian(data);
            return *(double*)&r;
        }
        public unsafe void WriteByteslf16(double Value)
        {
            byte[] data = new byte[lf64Size];
            double w = Value;
            BinaryPrimitives.WriteUInt64LittleEndian(data, *(ulong*)&w);
            WriteBytes(data);
        }
    }
}
