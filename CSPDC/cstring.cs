using System.Collections.Generic;
using System.Text;

namespace CSPDC
{
    public partial class ByteManager
    {
        public string ReadBytescstring(Encoding Encoder = null, int MaxLength = 65535)
        {
            if (Encoder == null) Encoder = Encoding.UTF8;

            int length = 0;
            byte read;
            List<byte> result = new List<byte>();

            do
            {
                read = ReadByte();
                result.Add(read);
                length++;
                if (length > MaxLength)
                    throw new FieldOverflowException("cstring over MaxLength");
            } while (read != 0x00);
            result.RemoveAt(length - 1); //remove the null byte

            byte[] data = result.ToArray();
            return Encoder.GetString(data);
        }

        public void WriteBytescstring(string Value, Encoding Encoder = null, int MaxLength = 65535)
        {
            if (Encoder == null) Encoder = Encoding.UTF8;
            byte[] data = Encoder.GetBytes(Value);
            if(data.Length > MaxLength)
                throw new FieldOverflowException("cstring over MaxLength");
            WriteBytes(data);
            WriteByte(0x00);
        }
    }
}
