using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructures.Stack
{
    public class ResizingArrayStack<T> : IStack<T>
    {
        private int index;
        private ResizableArray<T> data;
        public const int DefaultCapacity = 16;

        public int Count { get { return this.index; } }

        public ResizingArrayStack(int capacity)
        {
            this.data = new ResizableArray<T>(capacity);
        }
        public ResizingArrayStack()
        {
            this.data = new ResizableArray<T>();
        }

        public void Push(T obj)
        {
            if (index == data.Length)
                data.Expand();
            data[index++] = obj;
        }

        public T Pop()
        {
            if (index == 0)
                throw new InvalidOperationException("Empty stack");
            return data[--index];
        }

        public T Peek()
        {
            if (index == 0)
                throw new InvalidOperationException("Empty stack");
            return data[index - 1];
        }

        public bool IsEmpty()
        {
            return index == 0;
        }
    }
}
