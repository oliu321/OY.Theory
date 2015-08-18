using OY.Theory.Misc.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var data1 = new int[]{70,35,59,75,48,56,98,37,57,96,25,64};
            Sorter.Partition2(data1, 0, data1.Length - 1);
            Console.WriteLine(string.Join(" ", data1));

            var data2 = new int[] {57,68,31,75,57,79,57,45,54,78};
            Sorter.ThreeWayPartition(data2, 0, data2.Length - 1);
            Console.WriteLine(string.Join(" ", data2));
        }
    }
}
