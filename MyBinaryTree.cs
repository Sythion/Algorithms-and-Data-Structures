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

        public MyBinaryTreeNode<T> Find(T value)
        {
            var node = this.Root;
            if (this.Root == null)
            {
                throw new Exception("The binary tree is empty");
            }
            else
            {
                var result = this.Find(this.Root, value);
                if (result == null)
                {
                    throw new Exception("The item was not found");
                }
                else
                {
                    return result;
                }
            }
        }

        private MyBinaryTreeNode<T> Find(MyBinaryTreeNode<T> node, T value)
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
                    return this.Find(node.Left, value);
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
                    return this.Find(node.Right, value);
                }
            }
        }

        public MyBinaryTreeNode<T> Traverse()
        {
            if (this.Root == null)
            {
                throw new Exception("The binary tree is empty");
            }
        }

        private MyBinaryTreeNode<T> Traverse(MyBinaryTreeNode<T> node)
        {
            if (node.Left == null)
            {
                return node;
            }
            else
            {
                return this.Traverse(node.Left);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {           
            var node = this.Root;

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