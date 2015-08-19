using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Randomized.Distribution
{
    public class ThreadSafeRandomGenerator : IRandomGenerator
    {
        /// <summary>
        /// Random instance shared among all threads
        /// </summary>
        private static readonly Random global = new Random();

        /// <summary>
        /// Random instance for each thread
        /// </summary>
        [ThreadStatic]
        private static Random threadLocal;

        /// <summary>
        /// Constructor to initialize instance at thread level
        /// No need worry about sync on threadLocal as there will be one instance per thread
        /// </summary>
        public ThreadSafeRandomGenerator()
        {
            if (ThreadSafeRandomGenerator.threadLocal == null)
            {
                int seed;
                lock (ThreadSafeRandomGenerator.global)
                {
                    seed = global.Next();
                }
                ThreadSafeRandomGenerator.threadLocal = new Random(seed);
            }
        }

        /// <summary>
        /// Returns a nonnegative random number
        /// </summary>
        /// <returns>A nonnegative random number</returns>
        public int Next()
        {
            return ThreadSafeRandomGenerator.threadLocal.Next();
        }

        /// <summary>
        /// Return a nonnegative random number less than the specific number
        /// </summary>
        /// <param name="maxValue">The specific number</param>
        /// <returns>A nonnegative random number less than the specific number</returns>
        public int Next(int maxValue)
        {
            return ThreadSafeRandomGenerator.threadLocal.Next(maxValue);
        }
    }
}
