using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.NumberTheory
{
    /// <summary>
    /// Greatest common divisor algorithms, based on Euclidean Algorithm mostly.
    /// </summary>
    public class GreatestCommonDivisor
    {
        /// <summary>
        /// Get gcd(a,b)
        /// </summary>
        /// <param name="a">a in gcd(a,b)</param>
        /// <param name="b">b in gcd(a,b)</param>
        /// <returns>gcd(a,b)</returns>
        public static uint GCD(int a, int b)
        {
            return GCD_Unsigned((uint) (a < 0 ? -a : a), (uint) (b < 0 ? -b : b));
        }

        /// <summary>
        /// Get gcd(a,b) where a and b are unsigned
        /// </summary>
        /// <param name="a">a in gcd(a,b)</param>
        /// <param name="b">b in gcd(a,b)</param>
        /// <returns>gcd(a,b)</returns>
        public static uint GCD_Unsigned(uint a, uint b)
        {
            if (a > b)
            {
                if (b == 0)
                    return a;
                return GCD_Unsigned(a % b, b);
            }
            else
            {
                if (a == 0)
                    return b;
                return GCD_Unsigned(a, b % a);
            }
        }

        /// <summary>
        /// Get gcd(a,b) and the s, t such that sa + tb = gcd(a,b)
        /// </summary>
        /// <param name="a">a in gcd(a,b)</param>
        /// <param name="b">b in gcd(a,b)</param>
        /// <returns>gcd(a,b), s, t</returns>
        public static Tuple<uint, int, int> Pulverize(int a, int b)
        {
            uint na = (uint)(a < 0 ? -a : a), nb = (uint)(b < 0 ? -b : b);
            var uresult = Pulverize_Unsigned(na, nb);
            return new Tuple<uint, int, int>(uresult.Item1, (a < 0 ? -uresult.Item2 : uresult.Item2), (b < 0 ? -uresult.Item3 : uresult.Item3));
        }

        /// <summary>
        /// Get gcd(a,b) and the s, t such that sa + tb = gcd(a,b) for unsigned a and b
        /// </summary>
        /// <param name="a">a in gcd(a,b)</param>
        /// <param name="b">b in gcd(a,b)</param>
        /// <returns>gcd(a,b), s, t</returns>
        public static Tuple<uint, int, int> Pulverize_Unsigned(uint a, uint b)
        {
            if (a > b)
            {
                if (b == 0)
                    return new Tuple<uint,int,int>(a, 1, 0);
                var result = Pulverize_Unsigned(a % b, b);
                return new Tuple<uint, int, int>(result.Item1, result.Item2, result.Item3 - result.Item2 * (int)(a/b));
            }
            else
            {
                if (a == 0)
                    return new Tuple<uint, int, int>(b, 0, 1);
                var result = Pulverize_Unsigned(a, b % a);
                return new Tuple<uint, int, int>(result.Item1, result.Item2 - result.Item3 * (int)(b / a), result.Item3);
            }
        }
    }
}
