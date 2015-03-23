using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OY.Theory.DataStructures
{
    /// <summary>
    /// Tarjan's disjoint set implementation
    /// </summary>
    /// <typeparam name="TElement">Type of element</typeparam>
    public class DisjointSets<TElement>
    {
        /// <summary>
        /// Node to hold a conencted component
        /// </summary>
        public class DisjointTreeNode
        {
            public uint Rank { get; set; }
            public DisjointTreeNode Parent { get; set; }

            protected TElement Value { public get; protected set; }
            public DisjointTreeNode(TElement value)
            {
                this.Value = value;
                this.Parent = this;
            }
        }

        /// <summary>
        /// Create a new set out of element x
        /// </summary>
        /// <param name="x">The element which is going to be a singleton</param>
        /// <returns>The set which has only one element: x</returns>
        public DisjointTreeNode MakeSet(TElement x)
        {
            return new DisjointTreeNode(x);
        }

        /// <summary>
        /// Connect the component of x and component of y
        /// </summary>
        /// <param name="x">The compoent in which x is a part</param>
        /// <param name="y">The compoent in which y is a part</param>
        public void Union(DisjointTreeNode x, DisjointTreeNode y)
        {
            var nodeX = FindSet(x);
            var nodeY = FindSet(y);
            if (!nodeX.Equals(nodeY))
                Link(FindSet(x), FindSet(y));
        }

        /// <summary>
        /// Find the tree node which represents the whole component in which x is a part
        /// </summary>
        /// <param name="x">The element's representation which typically was returned by the MakeSet call</param>
        /// <returns>The root element representing the component including x</returns>
        public DisjointTreeNode FindSet(DisjointTreeNode x)
        {
            if (!x.Equals(x.Parent))
            {
                x.Parent = FindSet(x.Parent);
            }
            return x.Parent;
        }

        /// <summary>
        /// Decide whether x and y are in the same component
        /// </summary>
        /// <param name="x">The element x</param>
        /// <param name="y">The element y</param>
        /// <returns>true if x and y are in the same component, false otherwise</returns>
        public bool IsInSameSet(DisjointTreeNode x, DisjointTreeNode y)
        {
            return FindSet(x).Equals(FindSet(y));
        }

        /// <summary>
        ///  Link the 2 root elements of 2 different components using union by rank and path compression
        /// </summary>
        /// <param name="x">The root element x</param>
        /// <param name="y">The root element y</param>
        protected void Link(DisjointTreeNode x, DisjointTreeNode y)
        {
            if (x.Rank > y.Rank)
                y.Parent = x;
            else
            {
                x.Parent = y;
                if (x.Rank == y.Rank)
                    ++y.Rank;
            }
        }
    }
}
