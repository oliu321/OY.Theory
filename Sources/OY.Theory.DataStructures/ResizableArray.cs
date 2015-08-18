﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructures
{
    public sealed class ResizableArray<T> : IEnumerable<T>
    {
        private T[] data;
        public const int DefaultCapacity = 16;
        public ResizableArray(int capacity)
        {
            this.data = new T[capacity <= 0 ? 1 : capacity];
        }

        public ResizableArray() : this(DefaultCapacity) { }
        public T this[int i]
        {
            get { return this.data[i]; }
            set { this.data[i] = value; }
        }

        public int Length { get { return this.data.Length; } }

        public void Expand()
        {
            this.Expand(this.data.Length * 2);
        }

        public void Expand(int newCapacity)
        {
            if (newCapacity <= this.data.Length)
                return;

            T[] newData = new T[newCapacity];
            Array.Copy(this.data, newData, this.data.Length);
            this.data = newData;
        }

        public void Shrink()
        {
            this.Shrink(this.data.Length / 2);
        }

        public void Shrink(int newCapacity)
        {
            if (newCapacity >= this.data.Length)
                return;
            if (newCapacity <= 0)
                newCapacity = 1;

            T[] newData = new T[newCapacity];
            Array.Copy(this.data, newData, newCapacity);
            this.data = newData;
        }

        public void Resize(int newCapacity)
        {
            if (newCapacity > this.data.Length)
                this.Expand(newCapacity);
            else
                this.Shrink(newCapacity);  
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this.data).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }
    }
}
