namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class MyBinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public MyBinaryTreeNode<T> Root { get; set; }
        
        public int Count { get; set; }
        
        public void Add(T item)
        {
            if (this.Root == null)
            {
                this.Root = new MyBinaryTreeNode<T>(item);
            }
            else
            {
                this.Add(this.Root, item);
            }

            this.Count++;
        }

        private void Add(MyBinaryTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new MyBinaryTreeNode<T>(value);
                }
                else
                {
                    this.Add(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new MyBinaryTreeNode<T>(value);
                }
                else
                {
                    this.Add(node.Right, value);
                }
            }
        }

        public bool Contains(T value)
        {
            MyBinaryTreeNode<T> parent;
            return this.FindWithParent(value, out parent) != null;
        }

        private MyBinaryTreeNode<T> FindWithParent(T value, out MyBinaryTreeNode<T> parent)
        {
            var current = this.Root;
            parent = null;
            while (current != null)
            {
                if (value.CompareTo(current.Value) < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (value.CompareTo(current.Value) > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else 
                {
                    // Match
                    break;
                }
            }

            return current;
        }

        public void Remove(T value)
        {
            MyBinaryTreeNode<T> parent;
            var node = this.FindWithParent(value, out parent);

            // Case 1
            if (node.Right == null)
            {

            }
        }

        public IEnumerator<T> GetEnumerator()
        {           
            yield return this.Root.Value;
            yield return this.Root.Left.Value;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class MyBinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public MyBinaryTreeNode(TNode value)
        {
            this.Value = value;
        }
        
        public TNode Value { get; set;}
        
        public MyBinaryTreeNode<TNode> Left { get; set; }
        
        public MyBinaryTreeNode<TNode> Right { get; set; }

        public int CompareTo(TNode other)
        {
            return this.Value.CompareTo(other);
        }
    }
}