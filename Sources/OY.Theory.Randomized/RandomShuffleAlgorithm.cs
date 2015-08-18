using OY.Theory.Randomized.Distribution;
using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Randomized
{
    /// <summary>
    /// All kinds of random shuffle algorithms
    /// </summary>
    public static class RandomShuffleAlgorithm
    {
        public static void Shuffle<T>(IList<T> data)
        {
            Shuffle(data, new SystemRandomGenerator());
        }

        public static void Shuffle<T>(IList<T> data, IRandomGenerator randomGenerator)
        {
            for (int i = data.Count - 1; i >= 0; --i)
            {
                int j = randomGenerator.Next(i+1);
                if (j != i)
                {
                    var t = data[j];
                    data[j] = data[i];
                    data[i] = t;
                }
            }
        }

        public static int[] GenerateRandomIntArray(int length)
        {
            int[] result = new int[length];
            for (int i = 0; i < result.Length; ++i)
                result[i] = i;

            RandomShuffleAlgorithm.Shuffle(result);

            return result;
        }

    }
}
