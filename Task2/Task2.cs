using System;


namespace Task2
{
    public static class Task2
    {
        ///<summary>
        /// The method convert to binary View
        ///</summary>
        /// <param name="number">Initial value</param>
        ///<returns>binary View string</returns>
        public static string BinaryView(this double number)
        {
            long bits = BitConverter.DoubleToInt64Bits(number);
            string val = Convert.ToString(bits, 2);
            if (bits > 0)
            {
                string sing = Convert.ToString((bits >> 63),2);
                return val.Insert(0,sing);
            }
                
            
            return val;
           
        }
    }
}
