using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructures.Stack
{
    public interface IStack<T>
    {
        void Push(T obj);
        T Pop();
        T Peek();
        bool IsEmpty();
    }
}
