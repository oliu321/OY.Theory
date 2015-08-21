using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructure
{
    public class PostOrderBinaryTreeEnumerator<T> : IEnumerator<T>
    {
        private IBinaryTreeNode<T> root;
        private IBinaryTreeNode<T> current;
        public PostOrderBinaryTreeEnumerator(IBinaryTreeNode<T> root)
        {
            this.root = root;
            this.current = root;
        }
        public T Current
        {
            get { return this.current.Data; }
        }

        public void Dispose()
        {
            this.root = null;
        }

        object System.Collections.IEnumerator.Current
        {
            get { return this.current.Data; }
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            this.current = this.root;
        }
    }
}
