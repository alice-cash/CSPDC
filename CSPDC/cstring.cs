using System.Collections.Generic;
using System.Text;

namespace CSPDC
{
    public struct cstring : IDataType
    {
        public string Value { get; set; }

        public int MaxLength { get; set; }
        public Encoding Encoder { get; set; }

        public void ReadBytes(ByteReader br)
        {
            if (MaxLength == 0) MaxLength = 65535;
            if (Encoder == null) Encoder = Encoding.UTF8;

            int length = 0;
            byte read;
            List<byte> result = new List<byte>();

            do
            {
                read = br.ReadByte();
                result.Add(read);
                length++;
                if (length > MaxLength)
                    throw new FieldOverflowException("cstring over MaxLength");
            } while (read != 0x00);
            result.RemoveAt(length - 1); //remove the null byte

            byte[] data = result.ToArray();
            Value = Encoder.GetString(data);
        }

        public void WriteBytes(ByteWriter bw)
        {
            if (MaxLength == 0) MaxLength = 65535;
            if (Encoder == null) Encoder = Encoding.UTF8;
            byte[] data = Encoder.GetBytes(Value);
            if(data.Length > MaxLength)
                throw new FieldOverflowException("cstring over MaxLength");
            bw.WriteBytes(data);
            bw.WriteByte(0x00);
        }
    }
}
