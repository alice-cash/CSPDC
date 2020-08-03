using System;
using System.Collections.Generic;
using System.Text;

namespace CSPDC
{
    public class FieldOverflowException: Exception
    {
        public FieldOverflowException() : base() { }
        public FieldOverflowException(string message): base(message) { }
    }
}
