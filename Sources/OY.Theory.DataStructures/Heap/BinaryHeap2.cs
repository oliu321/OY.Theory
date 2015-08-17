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
        private ResizableArray<T> data;

        /// <summary>
        /// We at most support 64M items
        /// </summary>
        public const int MaxSize = 1024 * 1024 * 64;

        private bool SafeGetAtIndex(int i, ref T item)
        {
            if (i < 0 || i >= this.count)
                return false;
            item = this.data[i];
            return true;
        }

        private void Swap(int i, int j)
        {
            T t = data[i];
            this.data[i] = this.data[j];            
            this.data[j] = t;
            this.data[i].HeapLocation = i;
            this.data[j].HeapLocation = j;
        }

        private void Sink(int i)
        {
            while(i >= 0 && i < this.count)
            {
                int l = 2 * (i + 1) - 1;
                if (l >= this.count)
                    return;

                int min = i;
                if (this.data[l].CompareTo(this.data[i]) < 0)
                    min = l;

                int r = 2 * (i + 1);
                if (r < this.count && this.data[r].CompareTo(this.data[min]) < 0)
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
                if (this.data[p].CompareTo(this.data[i]) <= 0)
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

        public BinaryHeap2 (ICollection<T> source)
        {
            if (source == null)
                return;

            this.count = source.Count;
            this.data = new ResizableArray<T>(source.Count);
            int i = 0;
            foreach (var t in source)
            {
                this.data[i] = t;
                this.data[i].HeapLocation = i;
                ++i;
            }
            this.Heapify();
        }
        public BinaryHeap2 (int capacity)
        {
            this.count = 0;
            data = new ResizableArray<T>(capacity);
        }
        public BinaryHeap2() : this(16) { }
        public IHeap<T> Insert(T node)
        {
            ++this.count;
            if (this.count > this.data.Length)
                this.data.Expand();
            this.data[this.count - 1] = node;
            node.HeapLocation = this.count - 1;
            BubbleUp(this.count - 1);

            return this;
        }

        public int InsertAndReturnLocation(T node)
        {
            ++this.count;
            if (this.count > this.data.Length)
                this.data.Expand();
            this.data[this.count - 1] = node;
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
            return this.data[0];
        }

        public T ExtractMin()
        {
            if (this.count == 0)
                throw new InvalidOperationException("Empty Queue");

            Swap(0, --this.count);
            Sink(0);
            return this.data[count];
        }        

        public int Count()
        {
            return this.count;
        }
    }
}
