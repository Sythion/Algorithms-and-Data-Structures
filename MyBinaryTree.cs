namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    public class MyBinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public MyBinaryTreeNode<T> Root { get; set; }
        
        public int Count { get; set; }
        
        public void Add(T value)
        {
            if (this.Root == null)
            {
                this.Root = new MyBinaryTreeNode<T>(value);
            }
            else
            {
                this.AddTo(this.Root, value);
            }
            
            this.Count++;
        }
        
        public void AddTo(MyBinaryTreeNode<T> node, T value)
        {
            if(value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new MyBinaryTreeNode<T>(value);	
                }
                else
                {
                    this.AddTo(node.Left, value);	
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
                    this.AddTo(node.Right, value);	
                }
            }
        }
        
        public MyBinaryTreeNode<T> Find(T value)
        {
            if (this.Root == null)
            {
                return null;
            }
            else
            {
                return this.FindAt(this.Root, value);
            }
        }

        public MyBinaryTreeNode<T> FindAt(MyBinaryTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) == 0)
            {
                return node;	
            }
            else if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    return null;	
                }
                else
                {
                    return this.FindAt(node.Left, value);	
                }
            }
            else
            {
                if (node.Right == null)
                {
                    return null;
                }
                else
                {
                    return this.FindAt(node.Right, value);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.Root;
            while (current != null)
            {
                current = this.Root.Left;
            }
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