using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Shared
{
    /// <summary>
    /// Implementation of IComparer{T} based on another one;
    /// this simply reverses the original comparison.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ReverseComparer2<T> : IComparer<T> where T : IComparable<T>
    {
        /// <summary>
        /// Returns the result of comparing the specified values using the original
        /// comparer, but reversing the order of comparison.
        /// </summary>
        public int Compare(T x, T y)
        {
            return -1 * ((IComparable<T>)x).CompareTo(y);
        }
    }
}
