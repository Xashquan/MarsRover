using System;

namespace MarsRover.Utils
{
    public static class EnumUtil
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
