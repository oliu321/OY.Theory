using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.Shared
{
    public interface IBinaryTreeNode<T>
    {
        IBinaryTreeNode<T> LeftChild { get; }
        IBinaryTreeNode<T> RightChild { get; }
        IBinaryTreeNode<T> Parent { get; }
        T Data { get; }
    }
}
