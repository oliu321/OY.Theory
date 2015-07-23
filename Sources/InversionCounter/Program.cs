using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OY.Theory.Misc.Sorting;

namespace InversionCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = File.ReadLines(args[0]).Select(s => int.Parse(s)).ToArray();
            Console.WriteLine("Inversion count: {0}", Sorter.MergeSortWithInversionCounting(numbers).Item2);
        }
    }
}
