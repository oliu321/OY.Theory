using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructures.Queue
{
    public interface IQueue<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
        bool IsEmpty();

        T[] ToArray();
    }
}
