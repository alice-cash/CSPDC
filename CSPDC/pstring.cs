using System.Text;

namespace CSPDC
{
    public struct pstring : IDataType
    {
        public string Value { get; set; }
        public Encoding Encoder { get; set;  }

        public void ReadBytes(ByteReader br)
        {
            if(Encoder == null) Encoder = Encoding.UTF8;
            
            varint length = new varint();
            length.ReadBytes(br);
            br.Enforce(length.Value);

            byte[] data = br.ReadBytes(length.Value);
            Value = Encoder.GetString(data);
        }

        public void WriteBytes(ByteWriter bw)
        {
            if (Encoder == null) Encoder = Encoding.UTF8;
            byte[] data = Encoder.GetBytes(Value);
            varint length = data.Length;
            length.WriteBytes(bw);
            bw.WriteBytes(data);
        }
    }
}
