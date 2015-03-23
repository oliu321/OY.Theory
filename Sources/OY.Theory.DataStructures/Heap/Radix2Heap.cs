using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructures.Heap
{
    /// <summary>
    /// Regular radix 2 heap used for heap sort
    /// </summary>
    /// <typeparam name="THeapNode">The node in the heap</typeparam>
    public class Radix2Heap<THeapNode> : IHeap<THeapNode> where THeapNode : IHeapNode
    {
        /// <summary>
        /// Used to make a heap out of an array of data
        /// </summary>
        /// <param name="data">Array of integer to be heapified</param>
        public Radix2Heap(int[] data)
        {

        }

        /// <summary>
        /// Create an empty heap and reserve the size of the heap
        /// </summary>
        /// <param name="maxSize">Max number of the nodes the heap will have</param>
        public Radix2Heap(int maxSize)
        {

        }
        /// <summary>
        /// Heapify the nodes array
        /// </summary>
        /// <param name="nodes">A list of nodes to be heapified</param>
        public Radix2Heap(THeapNode[] nodes)
        {

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
