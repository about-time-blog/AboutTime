namespace AboutTime
{
    internal static class ByteOperationHelper
    {
        public static int CountNumberOfOnes(this byte b)
        {
            var i = (int)b;
            i = i - ((i >> 1) & 0b01010101);
            i = (i & 0b00110011) + ((i >> 2) & 0b00110011);
            return (i + (i >> 4)) & 0b00001111;
        }
    }
}