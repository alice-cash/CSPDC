using System.Buffers.Binary;

namespace CSPDC
{
    public struct varint : IDataType
    {

        public int Value { get; set; }
        public varint(int value)
        {
            Value = value;
        }

        public void ReadBytes(ByteReader br)
        {
            br.Enforce(1);

            int result = 0;
            int numRead = 0;
            byte read;
            do
            {
                br.Enforce(1);
                read = br.ReadByte();
                int value = ((byte)read & 0b01111111);
                result |= (value << (7 * numRead));

                numRead++;
                if (numRead > 5)
                    throw new FieldOverflowException("varint too long");
            } while ((read & 0b10000000) != 0);
        }
        public void WriteBytes(ByteWriter bw)
        {
            byte[] data = new byte[5];
            byte length = 0;
            uint workingValue = (uint)Value;
            do
            {
                byte temp = (byte)(workingValue & 0b01111111);

                workingValue >>= 7;
                if (workingValue != 0)
                {
                    temp |= 0b10000000;
                }
                data[length] = temp;
                length++;
            } while (workingValue != 0);

            byte[] return_data = new byte[length];
            for (byte i = 0; i < length; i++)
            {
                return_data[i] = data[i];
            }
            bw.WriteBytes(data);
        }

        public static implicit operator varint(int value) => new varint(value);
        public static implicit operator int(varint value) => value.Value;

    }
}
