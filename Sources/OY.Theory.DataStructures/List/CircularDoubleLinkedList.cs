using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructures.List
{
    public class CircularDoubleLinkedList<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        #region Kernel Implementation
        public class CircularDoubleLinkedListNode<T> : IDisposable
        {
            public T Data { get; set; }
            public CircularDoubleLinkedListNode<T> Next { get; set; }
            public CircularDoubleLinkedListNode<T> Prev { get; set; }

            public void Dispose()
            {
                this.Next = null;
                this.Prev = null;
                this.Data = default(T);
            }
        }

        protected CircularDoubleLinkedListNode<T> sentinel;        
        protected int count;
        protected bool isReadOnly;

        protected Tuple<int, CircularDoubleLinkedListNode<T>> MoveToIndex(int index)
        {
            var p = sentinel.Next;            
            int i = 0;
            while (i < index && p != sentinel)
            {
                i++;
                p = p.Next;
            }

            return new Tuple<int, CircularDoubleLinkedListNode<T>>(i, p);
        }

        protected Tuple<int, CircularDoubleLinkedListNode<T>> MoveToItem(T item)
        {
            var p = sentinel.Next;            
            int i = 0;
            while (p != sentinel && !p.Data.Equals(item))
            {
                i++;
                p = p.Next;
            }

            return new Tuple<int, CircularDoubleLinkedListNode<T>>(i, p);
        }

        protected void AddInternal(CircularDoubleLinkedListNode<T> p, T item)
        {
            var node = new CircularDoubleLinkedListNode<T>
            {
                Data = item,
                Next = p,
                Prev = p.Prev,
            };
            p.Prev.Next = node;
            p.Prev = node;            
            ++this.count;
        }
        protected void RemoveInternal(CircularDoubleLinkedListNode<T> p)
        {
            p.Prev.Next = p.Next;
            p.Next.Prev = p.Prev;
            --this.count;
            p.Dispose();
        }
        #endregion
        #region Constructors
        public CircularDoubleLinkedList()
        {
            this.sentinel = new CircularDoubleLinkedListNode<T>();
            this.Clear();
        }

        public CircularDoubleLinkedList(IEnumerable<T> collection)
            : this()
        {
            foreach (var item in collection)
            {
                AddInternal(this.sentinel.Prev, item);
            }
        }
        #endregion

        #region IList<T> Implementation
        public int IndexOf(T item)
        {
            var result = MoveToItem(item);
            return result.Item2 == this.sentinel ? -1 : result.Item1;
        }
        public void Insert(int index, T item)
        {
            var result = MoveToIndex(index);
            if (result.Item1 != index)
                throw new ArgumentOutOfRangeException("Can't insert at index");

            AddInternal(result.Item2, item);
        }

        public void RemoveAt(int index)
        {
            var result = MoveToIndex(index);
            if (result.Item1 != index)
                throw new ArgumentOutOfRangeException("Can't insert at index");

            RemoveInternal(result.Item2);
        }

        public T this[int index]
        {
            get
            {
                var result = MoveToIndex(index);
                if (result.Item1 != index)
                    throw new ArgumentOutOfRangeException("Can't insert at index");
                return result.Item2.Data;
            }
            set
            {
                var result = MoveToIndex(index);
                if (result.Item1 != index)
                    throw new ArgumentOutOfRangeException("Can't insert at index");
                result.Item2.Data = value;
            }
        }
        #endregion

        #region ICollection<T> Implementation
        public void Add(T item)
        {
            AddInternal(this.sentinel.Prev, item);
        }

        public void Clear()
        {
            this.sentinel.Next = this.sentinel;
            this.sentinel.Prev = this.sentinel;
            this.count = 0;
        }

        public bool Contains(T item)
        {
            var result = MoveToItem(item);
            return result.Item2 != this.sentinel;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var p = this.sentinel.Next;
            int i = 0;
            while (p != this.sentinel)
            {
                array[arrayIndex + i] = p.Data;
                p = p.Next;
            }
        }
        
        public int Count
        {
            get { return this.count; }
        }

        public bool IsReadOnly
        {
            get { return this.isReadOnly; }
        }

        public bool Remove(T item)
        {
            var result = MoveToItem(item);
            if (result.Item2 == this.sentinel)
                return false;
            RemoveInternal(result.Item2);
            return true;
        }
        #endregion

        #region IEnumerator<T> Implementation
        public class CircularDoubleLinkedListEnumerator<T> : IDisposable, IEnumerator<T>
        {
            private CircularDoubleLinkedListNode<T> sentinel;
            private CircularDoubleLinkedListNode<T> current;

            public CircularDoubleLinkedListEnumerator(CircularDoubleLinkedListNode<T> sentinel)
            {
                this.sentinel = sentinel;
                this.current = sentinel;
            }

            public void Dispose()
            {
                this.sentinel = null;
                this.current = null;
            }

            public T Current
            {
                get { return this.current.Data; }
            }

            object System.Collections.IEnumerator.Current
            {
                get { return this.current.Data; }
            }

            public bool MoveNext()
            {
                if (this.current.Next == this.sentinel)
                    return false;
                this.current = this.current.Next;
                return true;
            }

            public void Reset()
            {
                this.current = this.sentinel;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new CircularDoubleLinkedListEnumerator<T>(this.sentinel);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new CircularDoubleLinkedListEnumerator<T>(this.sentinel);
        }
        #endregion
    }
}
