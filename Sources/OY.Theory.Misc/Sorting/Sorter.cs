﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Misc.Sorting
{
    public class Sorter
    {
        public delegate int PickPivot(int[] data, int l, int r);

        public static int Partition2(int[] data, int l, int r)
        {
            int i = l, j = r + 1;
            int x = data[l];
            while(true)
            {
                while (data[++i] < x) if (i == r) break;
                while (x < data[--j]) if (j == l) break;
                if (i >= j) break;
                ArraySwap(data, i, j);
            }
            ArraySwap(data, l, j);
            return j;
        }

        public static Tuple<int, int> ThreeWayPartition(int[] data, int lo, int hi)
        {
            if (hi <= lo) return null;
            int lt = lo, i = lo + 1, gt = hi;
            int v = data[lo];
            while (i <= gt)
            {
                int cmp = data[i] - v;
                if (cmp < 0) ArraySwap(data, lt++, i++);
                else if (cmp > 0) ArraySwap(data, i, gt--);
                else i++;
            } // Now a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi].
            return new Tuple<int, int>(lt, gt);
        }

        public static void QuickSort3(int[] data, int l, int r)
        {
            if (l <= r)
                return;
            var result = ThreeWayPartition(data, l, r);
            QuickSort3(data, l, result.Item1 - 1);
            QuickSort3(data, result.Item2 + 1, r);
        }
        public static void QuickSort2(int[] data, int l, int r)
        {
            if (l <= r)
                return;
            int m = Partition2(data, l, r);
            QuickSort2(data, l, m - 1);
            QuickSort2(data, m + 1, r);
        }
        public static int QuickSort(int[] data, int l, int r, PickPivot pivotFunc)
        {
            if (l >= r)
                return 0;

            int p = pivotFunc(data, l, r);
            ArraySwap(data, l, p);
            int i = l + 1;
            for (int j = l + 1; j <= r; ++j)
            {
                if (data[j] < data[l])
                {
                    ArraySwap(data, j, i++);
                }
            }
            ArraySwap(data, l, i - 1);
            return r - l + QuickSort(data, l, i - 2, pivotFunc) + QuickSort(data, i, r, pivotFunc);
        }

        public static void ArraySwap(int[] data, int i, int j)
        {
            int t = data[i];
            data[i] = data[j];
            data[j] = t;
        }

        public static int PickFirstPivot(int[] data, int l, int r)
        {
            return l;
        }

        public static int PickLastPivot(int[] data, int l, int r)
        {
            return r;
        }

        public static int PickMedianPivot(int[] data, int l, int r)
        {
            int m = (l + r) / 2;
            if((data[l] <= data[m] && data[m] <= data[r]) || (data[r] <= data[m] && data[m] <= data[l]))
                return m;
            else if ((data[m] <= data[l] && data[l] <= data[r]) || (data[r] <= data[l] && data[l] <= data[m]))
                return l;
            else
                return r;
        }
        public static Tuple<int[], long> MergeSortWithInversionCounting(int[] original)
        {
            if (original.Length <= 1)
                return new Tuple<int[], long>(original, 0);

            int[] lhs = new int[original.Length / 2];
            int[] rhs = new int[original.Length - original.Length / 2];
            for(int i = 0; i < original.Length; ++i)
            {
                if (i < lhs.Length)
                    lhs[i] = original[i];
                else
                    rhs[i - lhs.Length] = original[i];
            }

            var lhs_result = MergeSortWithInversionCounting(lhs);
            var rhs_result = MergeSortWithInversionCounting(rhs);
            var merge_result = MergeInOrderWithInversion(lhs_result.Item1, rhs_result.Item1);
            return new Tuple<int[], long>(merge_result.Item1, merge_result.Item2 + lhs_result.Item2 + rhs_result.Item2);
        }

        public static Tuple<int[], long> MergeInOrderWithInversion(int[] lhs, int[] rhs)
        {
            var result = new int[lhs.Length + rhs.Length];
            int l = 0, r = 0, i = 0;
            long inversion = 0;

            while(l < lhs.Length && r < rhs.Length)
            {
                if (lhs[l] <= rhs[r])
                    result[i++] = lhs[l++];
                else
                {
                    result[i++] = rhs[r++];
                    inversion += lhs.Length - l;
                }
            }

            while (l < lhs.Length)
                result[i++] = lhs[l++];

            while (r < rhs.Length)
                result[i++] = rhs[r++];

            return new Tuple<int[],long>(result, inversion);
        }
    }
}
