using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructures.Queue
{
    public class ResizingArrayQueue<T> : IQueue<T>
    {
        private int head;
        private int tail;
        private int count = 0;
        private ResizableArray<T> data;
        public const int DefaultCapacity = 16;

        public int Count { get { return this.count; } }

        public ResizingArrayQueue() : this(DefaultCapacity) { }
        public ResizingArrayQueue(int capacity)
        {
            this.data = new ResizableArray<T>(capacity);
        }
        public void Enqueue(T item)
        {
            if (this.IsFull())
                data.Expand(this.ResizeDetail);

            ++this.count;
            this.data[this.tail++] = item;
            if (this.tail == this.data.Length) this.tail = 0;
        }

        public T Dequeue()
        {
            if(this.IsEmpty())
                throw new InvalidOperationException("Empty queue");

            --this.count;
            T item = this.data[this.head++];
            if (this.head == this.data.Length) this.head = 0;
            return item;
        }

        public T Peek()
        {
            if (this.IsEmpty())
                throw new InvalidOperationException("Empty queue");

            return this.data[this.head];
        }

        public bool IsEmpty()
        {
            return this.count == 0;
        }

        protected bool IsFull()
        {
            return this.count == this.data.Length;
        }        

        protected void ResizeDetail(T[] oldData, T[] newData)
        {
            if (this.tail <= this.head)
            {
                Array.Copy(oldData, newData, this.tail);
                Array.Copy(oldData, this.head, newData, newData.Length - oldData.Length + this.head, oldData.Length - this.head);
                this.head = newData.Length - oldData.Length + this.head;
            }
            else
            {
                Array.Copy(oldData, head, newData, head, tail - head);
            }
        }


        public T[] ToArray()
        {
            if (this.count == 0)
                return null;

            var array = new T[this.count];
            if (this.head < this.tail)
            {
                for (int i = this.head; i < this.tail; ++i)
                    array[i - this.head] = this.data[i];
            }
            else
            {
                for (int i = this.head; i < this.data.Length; ++i)
                    array[i - this.head] = this.data[i];
                for (int i = 0; i < this.tail; ++i)
                    array[i + this.data.Length - this.head] = this.data[i];
            }

            return array;
        }
    }
}
