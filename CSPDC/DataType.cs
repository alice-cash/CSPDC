
namespace CSPDC
{
    public enum DataType
    {
        @switch,
        option,

        /// <summary>Big endian signed byte (1 byte)</summary>
        i8,
        /// <summary>Big endian signed short (2 byte)</summary>
        i16,
        /// <summary>Big endian signed integer (4 byte)</summary>
        i32,
        /// <summary>Big endian signed long (8 byte)</summary>
        i64,

        /// <summary>Big endian unsigned byte long (1 byte)</summary>
        u8,
        /// <summary>Big endian unsigned byte long (1 byte)</summary>
        u16,
        /// <summary>Big endian unsigned byte long (1 byte)</summary>
        u32,
        /// <summary>Big endian unsigned byte long (1 byte)</summary>
        u64,

        /// <summary>Big endian float (4 byte)</summary>
        f32,
        /// <summary>Big endian double (8 byte)</summary>
        f64,

        /// <summary>Little endian signed byte (1 byte)</summary>
        li8,
        /// <summary>Little endian signed short (2 byte)</summary>
        li16,
        /// <summary>Little endian signed integer (4 byte)</summary>
        li32,
        /// <summary>Little endian signed long (8 byte)</summary>
        li64,

        /// <summary>Little endian unsigned byte (1 byte)</summary>
        lu8,
        /// <summary>Little endian unsigned short (2 byte)</summary>
        lu16,
        /// <summary>Little endian unsigned integer (4 byte)</summary>
        lu32,
        /// <summary>Little endian unsigned long (8 byte)</summary>
        lu64,

        /// <summary>Little endian float (2 byte)</summary>
        lf32,
        /// <summary>Little endian double (2 byte)</summary>
        lf64,

        /// <summary>
        /// An array of elements. 
        /// </summary>
        array,
        count,
        container,

        varint,
        boolean,
        pstring,
        buffer,
        @void,
        bitfield,
        cstring,
        mapper
    }
}
