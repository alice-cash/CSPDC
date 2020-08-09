using System.Text;

namespace CSPDC
{
    public partial class ByteManager
    {
        public string ReadBytesstring(Encoding Encoder = null)
        {
            if(Encoder == null) Encoder = Encoding.UTF8;
            
            int length = ReadBytesvarint();
            Enforce(length);

            byte[] data = ReadBytes(length);
            return Encoder.GetString(data);
        }

        public void WriteBytesstring(string Value, Encoding Encoder = null)
        {
            if (Encoder == null) Encoder = Encoding.UTF8;
            byte[] data = Encoder.GetBytes(Value);
            WriteBytesvarint(data.Length);
            WriteBytes(data);
        }
    }
}
