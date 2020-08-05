using System.Buffers.Binary;

namespace CSPDC
{
    public partial class ByteManager
    {
        public int ReadBytesvarint()
        {
            int result = 0;
            int numRead = 0;
            byte read;
            do
            {
                Enforce(1);
                read = ReadByte();
                int value = ((byte)read & 0b01111111);
                result |= (value << (7 * numRead));

                numRead++;
                if (numRead > 5)
                    throw new FieldOverflowException("varint too long");
            } while ((read & 0b10000000) != 0);
            return result;
        }
        public void WriteBytesvarint(int Value)
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
            WriteBytes(data);
        }
    }
}
