using System;
using System.Diagnostics;

namespace Task1
{
    public static class Task1
    {
        #region Delegates

        private static Func<Func<int, int, int>, int, int, int, int> GDCDelegateWithThree =
    (Func<int, int, int> GCD, int a, int b, int c) =>
    {
        int d;
        if (a == 0) d = GCD(b, c);
        else
        {
            d = GCD(a, b);
            d = GCD(d, c);
        }
        return d;
    };

        private static Func<Func<int, int, int>, int[], int> GDCDelegateWithArray =
           (Func<int, int, int> GCD, int[] numbers) =>
           {
               Array.Sort(numbers);
               int d = 0;
               for (int i = 0; i < numbers.Length - 1; i++)
               {
                   if (numbers[i] == 0)
                       continue;
                   d = GCD(d, numbers[i]);
               }
               if (d == 0)
                   throw new ArgumentException("Invalid value");
               return d;
           };
        #endregion
        #region Euclidean algorithm
        ///<summary>
        /// The method calculates GCD of two numbers
        ///</summary>
        /// <param name="a">Input value</param>
        /// <param name="b">Input value</param>
        ///<returns>GCD of two numbers</returns>
        public static int GCD(int a, int b)
        {
            if (a == 0 && b == 0) throw new ArgumentException("Invalid value. All  arguments can't be 0");
            if (a == 0) return b;
            if (b == 0) return a;
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }
        ///<summary>
        /// The method calculates GCD of two numbers
        ///</summary>
        /// <param name="a">Input value</param>
        /// <param name="b">Input value</param>
        /// <param name="time">time needed to complete the calculation</param>
        ///<returns>GCD of two numbers</returns>
        public static int GCD(int a, int b, out string time)
        {
            Stopwatch info = new Stopwatch();
            info.Start();
            int gcd = GCD(a, b);
            info.Stop();
            time = info.Elapsed.Seconds.ToString();
            return gcd;
        }
        ///<summary>
        /// The method calculates GCD of three numbers
        ///</summary>
        /// <param name="a">Input value</param>
        /// <param name="b">Input value</param>
        /// <param name="c">Input value</param>
        ///<returns>GCD of three numbers</returns>
        public static int GCD(int a, int b, int c)
        {
            return GDCDelegateWithThree(GCD,a, b, c);
        }
        ///<summary>
        /// The method calculates GCD of three numbers
        ///</summary>
        /// <param name="a">Input value</param>
        /// <param name="b">Input value</param>
        /// <param name="c">Input value</param>
        /// <param name="time">time needed to complete the calculation</param>
        ///<returns>GCD of three numbers</returns>
        public static int GCD(int a, int b, int c, out string time)
        {
            Stopwatch info = new Stopwatch();
            info.Start();
            int d = GDCDelegateWithThree(GCD, a, b, c);
            time = info.Elapsed.Seconds.ToString();
            return d;
        }
        ///<summary>
        /// The method calculates GCD of two numbers
        ///</summary>
        /// <param name="numbers">Input values</param>
        ///<returns>GCD of numbers</returns>
        public static int GCD(params int[] numbers)
        {
            return GDCDelegateWithArray(GCD, numbers);
        }
        ///<summary>
        /// The method calculates GCD of two numbers
        ///</summary>
        /// <param name="time">time needed to complete the calculation</param>
        /// <param name="numbers">Input values</param>
        ///<returns>GCD of numbers</returns>
        public static int GCD(out string time, params int[] numbers)
        {
            Stopwatch info = new Stopwatch();
            info.Start();
            int d = GDCDelegateWithArray(GCD, numbers);            
            time = info.Elapsed.Seconds.ToString();
            return d;
        }
        #endregion
        #region Binary algorithm
        ///<summary>
        /// The method calculates GCD of two numbers
        ///</summary>
        /// <param name="a">Input value</param>
        /// <param name="b">Input value</param>
        ///<returns>GCD of two numbers</returns>
        public static int BinaryGCD(int a, int b)
        {
            int shift;
            if (a == 0) return b;
            if (b == 0) return a;
            a = Math.Abs(a);
            b = Math.Abs(b);
            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                a >>= 1;
                b >>= 1;
            }
            while ((a & 1) == 0)
            {
                a >>= 1;
                do
                {
                    while ((b & 1) == 0)
                        b >>= 1;
                    if (a > b)
                    {
                        int t = b;
                        b = a;
                        a = t;
                    }
                    b = b - a;
                }
                while (b != 0);
            }
            return a << shift;
        }
        ///<summary>
        /// The method calculates GCD of two numbers
        ///</summary>
        /// <param name="a">Input value</param>
        /// <param name="b">Input value</param>
        /// <param name="time">time needed to complete the calculation</param>
        ///<returns>GCD of two numbers</returns>
        public static int BinaryGCD(int a, int b, out string time)
        {
            Stopwatch info = new Stopwatch();
            info.Start();
            int gcd = BinaryGCD(a, b);
            info.Stop();
            time = info.Elapsed.Seconds.ToString();
            return gcd;
        }
        ///<summary>
        /// The method calculates GCD of three numbers
        ///</summary>
        /// <param name="a">Input value</param>
        /// <param name="b">Input value</param>
        /// <param name="c">Input value</param>
        ///<returns>GCD of three numbers</returns>
        public static int BinaryGCD(int a, int b, int c)
        {
            return GDCDelegateWithThree(BinaryGCD, a, b, c);
        }
        ///<summary>
        /// The method calculates GCD of three numbers
        ///</summary>
        /// <param name="a">Input value</param>
        /// <param name="b">Input value</param>
        /// <param name="c">Input value</param>
        /// <param name="time">time needed to complete the calculation</param>
        ///<returns>GCD of three numbers</returns>
        public static int BinaryGCD(int a, int b, int c, out string time)
        {
            Stopwatch info = new Stopwatch();
            info.Start();
            int d = GDCDelegateWithThree(BinaryGCD, a, b, c);
            time = info.Elapsed.Seconds.ToString();
            return d;
        }
        ///<summary>
        /// The method calculates GCD of two numbers
        ///</summary>
        /// <param name="numbers">Input values</param>
        ///<returns>GCD of numbers</returns>
        public static int BinaryGCD(params int[] numbers)
        {
            return GDCDelegateWithArray(BinaryGCD, numbers);
        }
        ///<summary>
        /// The method calculates GCD of two numbers
        ///</summary>
        /// <param name="time">time needed to complete the calculation</param>
        /// <param name="numbers">Input values</param>
        ///<returns>GCD of numbers</returns>
        public static int BinaryGCD(out string time, params int[] numbers)
        {
            Stopwatch info = new Stopwatch();
            info.Start();
            Array.Sort(numbers);
            int d = GDCDelegateWithArray(BinaryGCD, numbers);
            time = info.Elapsed.Seconds.ToString();
            return d;
        }
        #endregion
    }
}