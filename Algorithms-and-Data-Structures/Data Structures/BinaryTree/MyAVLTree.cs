namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyAVLTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        #region Methods

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Classes

    public class MyAVLTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public MyAVLTreeNode(TNode value)
        {
            this.Value = value;
        }
        
        public TNode Value { get; set;}
        
        public MyAVLTreeNode<TNode> Left { get; set; }
        
        public MyAVLTreeNode<TNode> Right { get; set; }

        // Used only in post order traversal
        public bool Visited {get; set;}

        public int CompareTo(TNode other)
        {
            return this.Value.CompareTo(other);
        }
    }

#endregion
    }
}