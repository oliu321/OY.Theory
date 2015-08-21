using OY.Theory.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructures.BST
{
    public class NaiveBinarySearchTree<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public class NaiveBinarySearchTreeNode : IBinaryTreeNode<KeyValuePair<TKey, TValue>>
        {
            public IBinaryTreeNode<KeyValuePair<TKey, TValue>> LeftChild
            {
                get;
                set;
            }

            public IBinaryTreeNode<KeyValuePair<TKey, TValue>> RightChild
            {
                get;
                set;
            }

            public IBinaryTreeNode<KeyValuePair<TKey, TValue>> Parent
            {
                get;
                set;
            }

            public KeyValuePair<TKey, TValue> Data
            {
                get;
                set;
            }
        }

        protected NaiveBinarySearchTreeNode root;
        protected IComparer<TKey> comparer;

        private int Compare(TKey lhs, TKey rhs)
        {
            if (this.comparer == null)
                return ((IComparable<TKey>)lhs).CompareTo(rhs);
            return this.comparer.Compare(lhs, rhs);
        }

        protected NaiveBinarySearchTreeNode TryGetInternal(TKey key, ref NaiveBinarySearchTreeNode parent)
        {
            parent = null;
            var q = this.root;

            while(q != null)
            {
                int cmp = this.Compare(q.Data.Key, key);
                if (cmp == 0)
                    return q;
                else if (cmp < 0)
                {
                    parent = q;
                    q = (NaiveBinarySearchTreeNode)q.LeftChild;
                }
                else
                {
                    parent = q;
                    q = (NaiveBinarySearchTreeNode)q.RightChild;
                }
            }

            return q;
        }
        #region IDictionary<TKey, TValue> implementation
        public void Add(TKey key, TValue value)
        {
            if(this.root == null)
            {
                this.root = new NaiveBinarySearchTreeNode
                {
                    Data = new KeyValuePair<TKey, TValue>(key, value),
                };
            }

            NaiveBinarySearchTreeNode parent = null;
            var q = TryGetInternal(key, ref parent);
            if (q != null)
                throw new InvalidOperationException("Key already exists");
            int cmp = this.Compare(parent.Data.Key, key);
            if (cmp < 0)
            {
                parent.LeftChild = new NaiveBinarySearchTreeNode
                {
                    Parent = parent,
                    Data = new KeyValuePair<TKey,TValue>(key, value),
                };
            }
            else
            {
                parent.RightChild = new NaiveBinarySearchTreeNode
                {
                    Parent = parent,
                    Data = new KeyValuePair<TKey, TValue>(key, value),
                };
            }
        }

        public bool ContainsKey(TKey key)
        {
            NaiveBinarySearchTreeNode parent = null;
            var q = TryGetInternal(key, ref parent);
            return q != null;
        }

        public ICollection<TKey> Keys
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public ICollection<TValue> Values
        {
            get { throw new NotImplementedException(); }
        }

        public TValue this[TKey key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region ICollection<KeyValuePair<TKey, TValue>> implementation
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable implementation
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
