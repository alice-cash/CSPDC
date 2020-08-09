using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSPDC
{
    public partial class ByteManager
    {

        // private Stream _source;
        private Stream _sourceRead;
        private Stream _sourceWrite;

        private byte[] _readBuffer;
        private byte[] _writeBuffer;

        private int _avaliableRead = 0;
        private int _avaliableWrite = 0;

        private int _writePosition = 0;
        private int _readPosition = 0;

        private int _bufferSize;
        private int _bufferResizeThreshold;

        public ByteManager(Stream sourceRead, Stream sourceWrite, int bufferSize = 4096)
        {
            _sourceRead = sourceRead;
            _sourceWrite = sourceWrite;
            _readBuffer = new byte[bufferSize * 2];
            _writeBuffer = new byte[bufferSize];
            _bufferSize = bufferSize;
            _bufferResizeThreshold = (int)Math.Round(bufferSize * 0.75);
        }

        public byte[] ReadBytes(int length)
        {
            Enforce(length);
            byte[] returnData = new byte[length];
            Array.Copy(_readBuffer, _readPosition, returnData, 0, length);
            _avaliableRead -= length;
            _readPosition += length;
            ShiftReadIfNeeded();
            return returnData;
        }

        public byte ReadByte()
        {
            Enforce(1);
            byte returnData = _readBuffer[0];
            _avaliableRead -= 1;
            _readPosition += 1;
            ShiftReadIfNeeded();
            return returnData;
        }

        private void ShiftReadIfNeeded()
        {
            if (_readPosition > _bufferResizeThreshold)
            {
                Array.Copy(_readBuffer, _readPosition, _readBuffer, 0, _avaliableRead);
                _readPosition = 0;
            }

        }
        private void ReadToBuffer()
        {
            if (_sourceRead.Length > 0 && _avaliableRead < _bufferSize)
                _avaliableRead += _sourceRead.Read(_readBuffer, _avaliableRead + _readPosition, _bufferSize - _avaliableRead);
        }

        internal void Enforce(int v)
        {
            ReadToBuffer();
            if (_avaliableRead < v)
                throw new Exception("Not enough data to read");
        }

        public void WriteBytes(byte[] data)
        {
            if (data.Length > _bufferSize || data.Length + _writePosition > _bufferSize)
            {
                Write();
                _sourceWrite.Write(data);
                Write();
                return;
            }

            Array.Copy(data, 0, _writeBuffer, _writePosition, data.Length);
        }


        public void Flush()
        {
            if (_writePosition > 0) Write();
            _sourceWrite.Flush();
        }

        private void Write()
        {
            _sourceWrite.Write(_writeBuffer, 0, _writePosition);
            _writePosition = 0;
        }

        internal void WriteByte(byte value)
        {
            if (_writePosition + 1 > _bufferSize)
            {
                Write();
                _sourceWrite.WriteByte(value);
                Write();
                return;
            }
            _writePosition++;
            _writeBuffer[_writePosition] = value;
        }
    }
}
