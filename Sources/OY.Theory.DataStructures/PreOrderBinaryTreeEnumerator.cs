using OY.Theory.DataStructures.Stack;
using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructure
{
    public class PreOrderBinaryTreeEnumerator<T> : IEnumerator<T>
    {
        private IBinaryTreeNode<T> root;
        private IBinaryTreeNode<T> current;
        private ResizingArrayStack<IBinaryTreeNode<T>> stack;
        public PreOrderBinaryTreeEnumerator(IBinaryTreeNode<T> root)
        {
            this.root = root;
            this.stack = new ResizingArrayStack<IBinaryTreeNode<T>>();
            this.stack.Push(this.root);
        }
        public T Current
        {
            get { return this.current.Data; }
        }

        public void Dispose()
        {
            this.root = null;
            this.current = null;
            this.stack = null;
        }

        object System.Collections.IEnumerator.Current
        {
            get { return this.current.Data; }
        }

        public bool MoveNext()
        {
            if (this.stack.IsEmpty())
                return false;

            this.current = this.stack.Pop();
            if (this.current.RightChild != null)
                this.stack.Push(this.current.RightChild);
            if (this.current.LeftChild != null)
                this.stack.Push(this.current.LeftChild);            
            return true;
        }

        public void Reset()
        {
            this.current = this.root;
        }
    }
}
