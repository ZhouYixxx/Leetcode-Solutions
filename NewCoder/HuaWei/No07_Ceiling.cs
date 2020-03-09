using System;

namespace CodePractice.NewCoder.HuaWei
{
    public class No07_Ceiling
    {
        public static int Ceiling(float value)
        {
            var remainder = value - (int)value;
            if (remainder >= 0.5f)
            {
                return (int)value + 1;
            }
            return (int)value;
        }
    }
}