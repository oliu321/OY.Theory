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
    /// <typeparam name="THeapNode">The node in the heap</typeparam>
    public class FibonacciHeap<THeapNode> : IAdvancedHeap<THeapNode> where THeapNode : IHeapNode
    {
        public IHeap<THeapNode> Union(IHeap<THeapNode> heap2)
        {
            throw new NotImplementedException();
        }

        public IHeap<THeapNode> DecreaseKey(THeapNode node, IComparable newKey)
        {
            throw new NotImplementedException();
        }

        public IHeap<THeapNode> Delete(THeapNode node)
        {
            throw new NotImplementedException();
        }

        public IHeap<THeapNode> Insert(THeapNode node)
        {
            throw new NotImplementedException();
        }

        public THeapNode Min()
        {
            throw new NotImplementedException();
        }

        public THeapNode ExtractMin()
        {
            throw new NotImplementedException();
        }
    }
}
