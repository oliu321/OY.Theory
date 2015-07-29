/// <copyright file="PermutationGenerator.cs" company="Integration Co, Inc.">
///     Copyrights: ©2015   Integration Co, Inc. (DBA Finivation Software)
/// </copyright>
/// <author>Ou</author>

using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Combinatorics
{
    public static class PermutationGenerator
    {
        public static int[] GenerateRandomPermutation(int length)
        {
            int[] result = new int[length];
            for (int i = 0; i < result.Length; ++i)
                result[i] = i;

            var random = new Random();
            for(int i = length - 1; i > 0; --i)
            {
                int j = random.Next(i + 1);
                int t = result[i];
                result[i] = result[j];
                result[j] = t;
            }

            return result;
        }

        public static int[] GenerateRandomPermutation(int length, IRandomGenerator randomGenerator)
        {
            return null;
        }
    }
}