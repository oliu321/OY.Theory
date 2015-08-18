using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Shared
{
    /// <summary>
    /// The basic heap interface
    /// </summary>
    /// <typeparam name="T">The node in the heap</typeparam>
    public interface IHeap<T>
    {
        /// <summary>
        /// Insert node whose Key field has already been filled in, into the heap
        /// </summary>
        /// <param name="node">The node to be inserted</param>
        /// <returns>The new heap</returns>
        IHeap<T> Insert(T node);
        /// <summary>
        /// Return the node in the heap with the minimum Key
        /// </summary>
        /// <returns>The node with minimum Key</returns>
        T Min();
        /// <summary>
        /// Delete the node with the minimum key from the heap and return it
        /// </summary>
        /// <returns>The node with minimum Key</returns>
        T ExtractMin();        
    }

    /// <summary>
    /// Advanced heap to be used in shortest path tree, minimum spanning tree etc.
    /// </summary>
    /// <typeparam name="T">The type of the node in the heap</typeparam>
    public interface IAdvancedHeap<T> : IHeap<T> where T : IComparable<T>
    {
        /// <summary>
        /// Merge the current heap with all nodes in the heap2 and return a new heap
        /// </summary>
        /// <param name="heap2">The heap to be merged</param>
        /// <returns>A heap contains all nodes in current heap and the heap2</returns>
        IHeap<T> Union(IHeap<T> heap2);
        /// <summary>
        /// Assign the node a new key newKey, the node should be already in the heap and the newKey should be smaller than the current key of the node
        /// </summary>
        /// <param name="node">The node upon which the value will be decreased</param>
        /// <param name="newKey">The new key value to be decreased to</param>
        /// <returns>The modified heap</returns>
        IHeap<T> DecreaseKey(T node, IComparable newKey);
        /// <summary>
        /// Delete node from the heap, the node should be already in the heap
        /// </summary>
        /// <param name="node">The node to be deleted from the heap</param>
        /// <returns>The modified heap</returns>
        IHeap<T> Delete(T node);
    }
}
