using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructures.List
{
    public class SingleLinkedList<T> : IList<T>, ICollection<T>, IEnumerable<T>
    {
        #region Kernel Implementation
        public class SingleLinkedListNode<T> : IDisposable
        {
            public T Data { get; set; }
            public SingleLinkedListNode<T> Next { get; set; }

            public void Dispose()
            {
                this.Next = null;
                this.Data = default(T);
            }
        }

        protected SingleLinkedListNode<T> head;
        protected SingleLinkedListNode<T> tail;
        protected int count;
        protected bool isReadOnly;

        protected Tuple<int, SingleLinkedListNode<T>, SingleLinkedListNode<T>> MoveToIndex(int index)
        {
            var p = head;
            var q = head.Next;
            int i = 0;
            while (i < index && q != null)
            {
                i++;
                p = q;
                q = q.Next;
            }

            return new Tuple<int, SingleLinkedListNode<T>, SingleLinkedListNode<T>>(i, p, q);
        }

        protected Tuple<int, SingleLinkedListNode<T>, SingleLinkedListNode<T>> MoveToItem(T item)
        {
            var p = head;
            var q = head.Next;
            int i = 0;
            while (!q.Data.Equals(item) && q != null)
            {
                i++;
                p = q;
                q = q.Next;
            }

            return new Tuple<int, SingleLinkedListNode<T>, SingleLinkedListNode<T>>(i, p, q);
        }

        protected void AddInternal(SingleLinkedListNode<T> p, SingleLinkedListNode<T> q, T item)
        {
            if (p == null)
                p = this.head;

            var node = new SingleLinkedListNode<T>
            {
                Data = item,
                Next = q,
            };

            if (p.Next == null)
                tail = node;
            p.Next = node;
            ++this.count;
        }
        protected void RemoveInternal(SingleLinkedListNode<T> p, SingleLinkedListNode<T> q)
        {
            p.Next = q.Next;
            if (q == this.tail)
                this.tail = q;
            --this.count;
            q.Dispose();
        }
        #endregion

        #region Constructors
        public SingleLinkedList()
        {
            this.head = new SingleLinkedListNode<T>();
        }

        public SingleLinkedList(IEnumerable<T> collection)
            : this()
        {
            foreach (var item in collection)
            {
                AddInternal(this.tail, null, item);
            }
        }
        #endregion

        #region IList<T> Implementation
        public int IndexOf(T item)
        {
            var result = MoveToItem(item);
            return result.Item3 == null ? -1 : result.Item1;
        }
        public void Insert(int index, T item)
        {
            var result = MoveToIndex(index);
            if (result.Item1 != index)
                throw new ArgumentOutOfRangeException("Can't insert at index");

            AddInternal(result.Item2, result.Item3, item);
        }

        public void RemoveAt(int index)
        {
            var result = MoveToIndex(index);
            if (result.Item1 != index)
                throw new ArgumentOutOfRangeException("Can't insert at index");

            RemoveInternal(result.Item2, result.Item3);
        }

        public T this[int index]
        {
            get
            {
                var result = MoveToIndex(index);
                if (result.Item1 != index)
                    throw new ArgumentOutOfRangeException("Can't insert at index");
                return result.Item3.Data;
            }
            set
            {
                var result = MoveToIndex(index);
                if (result.Item1 != index)
                    throw new ArgumentOutOfRangeException("Can't insert at index");
                result.Item3.Data = value;
            }
        }
        #endregion

        #region ICollection<T> Implementation
        public void Add(T item)
        {
            AddInternal(this.tail, null, item);
        }

        public void Clear()
        {
            this.head.Next = null;
            this.tail = null;
            this.count = 0;
        }

        public bool Contains(T item)
        {
            var result = MoveToItem(item);
            return result.Item3 != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var p = head.Next;
            int i = 0;
            while (p != null)
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
            if (result.Item3 == null)
                return false;
            RemoveInternal(result.Item2, result.Item3);
            return true;
        }
#endregion

        #region IEnumerator<T> Implementation
        public class SingleLinkedListEnumerator<T> : IDisposable, IEnumerator<T>
        {
            private SingleLinkedListNode<T> head;
            private SingleLinkedListNode<T> current;

            public SingleLinkedListEnumerator(SingleLinkedListNode<T> head)
            {
                this.head = head;
                this.current = head;
            }

            public void Dispose()
            {
                this.head = null;
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
                if (this.current.Next == null)
                    return false;
                this.current = this.current.Next;
                return true;
            }

            public void Reset()
            {
                this.current = this.head;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new SingleLinkedListEnumerator<T>(this.head);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new SingleLinkedListEnumerator<T>(this.head);
        }
        #endregion
    }
}
