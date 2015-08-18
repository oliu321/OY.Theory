using OY.Theory.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructures.Heap
{
    public class BinaryHeap<T> : IHeap<T>, IEnumerable<T>
    {
        private int count;
        private ResizableArray<T> data;
        private IComparer<T> comparer;

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

        private bool Less(int i, int j)
        {
            if (this.comparer == null)
                return ((IComparable<T>)data[i]).CompareTo(data[j]) < 0;
            return this.comparer.Compare(data[i], data[j]) < 0;
        }

        private bool Great(int i, int j)
        {
            return !this.Less(j, i);
        }

        private void Swap(int i, int j)
        {
            T t = data[i];
            this.data[i] = this.data[j];
            this.data[j] = t;
        }

        private void Sink(int i)
        {
            while (i >= 0 && i < this.count)
            {
                int l = 2 * (i + 1) - 1;
                if (l >= this.count)
                    return;

                int min = i;
                if (this.Less(l, i))
                    min = l;

                int r = 2 * (i + 1);
                if (r < this.count && this.Less(r, min))
                    min = r;

                if (min == i)
                    return;
                Swap(i, min);
                i = min;
            }
        }

        private void Swim(int i)
        {
            while (i > 0)
            {
                int p = (i + 1) / 2 - 1;
                if (!this.Great(i, p))
                    return;
                Swap(i, p);
                i = p;
            }
        }

        private void Heapify()
        {
            for (int i = this.count / 2; i >= 0; --i)
            {
                Sink(i);
            }
        }

        public BinaryHeap(ICollection<T> source, IComparer<T> comparer = null)
        {
            this.comparer = comparer;
            if (this.comparer == null && !typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
                throw new ArgumentException("The source is not comparable and there is no comparer");

            if (source == null)
            {
                this.data = new ResizableArray<T>();
                return;
            }

            this.count = source.Count;
            this.data = new ResizableArray<T>(source.Count);
            int i = 0;
            foreach (var t in source)
                this.data[i++] = t;
            this.Heapify();
        }
        public BinaryHeap(int capacity, IComparer<T> comparer = null)
        {
            this.comparer = comparer;
            if (this.comparer == null && !typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
                throw new ArgumentException("The source is not comparable and there is no comparer");

            this.count = 0;
            data = new ResizableArray<T>(capacity);
        }
        public BinaryHeap() : this(16) { }
        public IHeap<T> Insert(T node)
        {
            ++this.count;
            if (this.count > this.data.Length)
                this.data.Expand();
            this.data[this.count - 1] = node;
            Swim(this.count - 1);

            return this;
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

        public IEnumerator<T> GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }
    }
}
