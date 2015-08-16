using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructures.Heap
{
    /// <summary>
    /// Binomial heap for advanced operations like union
    /// </summary>
    /// <typeparam name="T">The node in the heap</typeparam>
    public class BinomialHeap<T> : IAdvancedHeap<T> where T : IComparable<T>
    {
        public IHeap<T> Union(IHeap<T> heap2)
        {
            throw new NotImplementedException();
        }

        public IHeap<T> DecreaseKey(T node, IComparable newKey)
        {
            throw new NotImplementedException();
        }

        public IHeap<T> Delete(T node)
        {
            throw new NotImplementedException();
        }

        public IHeap<T> Insert(T node)
        {
            throw new NotImplementedException();
        }

        public T Min()
        {
            throw new NotImplementedException();
        }

        public T ExtractMin()
        {
            throw new NotImplementedException();
        }
    }
}
