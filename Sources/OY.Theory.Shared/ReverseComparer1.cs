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
    public sealed class ReverseComparer1<T> : IComparer<T>
    {
        readonly IComparer<T> originalComparer;

        /// <summary>
        /// Returns the original comparer; this can be useful to avoid multiple
        /// reversals.
        /// </summary>
        public IComparer<T> OriginalComparer
        {
            get { return originalComparer; }
        }

        /// <summary>
        /// Creates a new reversing comparer.
        /// </summary>
        /// <param name="original">The original comparer to use for comparisons.</param>
        public ReverseComparer1(IComparer<T> original)
        {
            if (original == null)
                throw new ArgumentException("original comparer is null");
            this.originalComparer = original;
        }

        /// <summary>
        /// Returns the result of comparing the specified values using the original
        /// comparer, but reversing the order of comparison.
        /// </summary>
        public int Compare(T x, T y)
        {
            return originalComparer.Compare(y, x);
        }
    }
}

