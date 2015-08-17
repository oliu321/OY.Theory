using OY.Theory.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructures.Heap
{
    public interface IHeapLocation
    {
        int HeapLocation { get; set; }
    }
    public class BinaryHeap2<T> : IHeap<T> where T : IComparable<T>, IHeapLocation
    {
        private int count;
        private T[] heap;

        /// <summary>
        /// We at most support 64M items
        /// </summary>
        public const int MaxSize = 1024 * 1024 * 64;

        private bool SafeGetAtIndex(int i, ref T item)
        {
            if (i < 0 || i >= this.count)
                return false;
            item = this.heap[i];
            return true;
        }

        private void Swap(int i, int j)
        {
            T t = heap[i];
            this.heap[i] = this.heap[j];            
            this.heap[j] = t;
            this.heap[i].HeapLocation = i;
            this.heap[j].HeapLocation = j;
        }

        private void ExpandArray()
        {
            T[] newHeap = new T[heap.Length * 2];
            Array.Copy(this.heap, newHeap, this.heap.Length);
            this.heap = newHeap;
        }

        private void Sink(int i)
        {
            while(i >= 0 && i < this.count)
            {
                int l = 2 * (i + 1) - 1;
                if (l >= this.count)
                    return;

                int min = i;
                if (this.heap[l].CompareTo(this.heap[i]) < 0)
                    min = l;

                int r = 2 * (i + 1);
                if (r < this.count && this.heap[r].CompareTo(this.heap[min]) < 0)
                    min = r;

                if (min == i)
                    return;
                Swap(i, min);
                i = min;
            }
        }

        private int BubbleUp(int i)
        {
            while (i > 0)
            {
                int p = (i + 1) / 2 - 1;
                if (this.heap[p].CompareTo(this.heap[i]) <= 0)
                    return i;
                Swap(i, p);
                i = p;
            }

            return i;
        }

        private void Heapify()
        {
            for(int i = this.count / 2; i >= 0; --i)
            {
                Sink(i);
            }
        }

        public BinaryHeap2 (ICollection source)
        {
            if (source == null)
                return;

            this.count = source.Count;
            this.heap = new T[source.Count];
            source.CopyTo(this.heap, 0);
            for (int i = 0; i < this.count; ++i)
                this.heap[i].HeapLocation = i;
            this.Heapify();
        }
        public BinaryHeap2 (int capacity)
        {
            this.count = 0;
            heap = new T[capacity];
        }
        public BinaryHeap2() : this(16) { }
        public IHeap<T> Insert(T node)
        {
            ++this.count;
            if (this.count > this.heap.Length)
                ExpandArray();
            this.heap[this.count - 1] = node;
            node.HeapLocation = this.count - 1;
            BubbleUp(this.count - 1);

            return this;
        }

        public int InsertAndReturnLocation(T node)
        {
            ++this.count;
            if (this.count > this.heap.Length)
                ExpandArray();
            this.heap[this.count - 1] = node;
            node.HeapLocation = this.count - 1;
            return BubbleUp(this.count - 1);            
        }

        public int DecreaseValue(int i)
        {
            return BubbleUp(i);
        }

        public T Min()
        {
            if (this.count == 0)
                throw new InvalidOperationException("Empty Queue");
            return this.heap[0];
        }

        public T ExtractMin()
        {
            if (this.count == 0)
                throw new InvalidOperationException("Empty Queue");

            Swap(0, --this.count);
            Sink(0);
            return this.heap[count];
        }        

        public int Count()
        {
            return this.count;
        }
    }
}
