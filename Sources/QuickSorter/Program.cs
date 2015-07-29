using OY.Theory.Misc.Sorting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = File.ReadLines(args[0]).Select(s => int.Parse(s)).ToArray();
            Console.WriteLine("{0} comparisons", Sorter.QuickSort(numbers, 0, numbers.Length - 1, Sorter.PickMedianPivot));
            bool failed = false;
            for (int i = 0; i < numbers.Length - 1; ++i)
            {
                if (numbers[i] > numbers[i+1])
                {
                    failed = true;
                    break;
                }
            }
            Console.WriteLine("{0}", failed ? "Failed" : "Succeeded");
        }
    }
}
