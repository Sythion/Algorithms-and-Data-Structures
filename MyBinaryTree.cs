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

        public bool Remove(T value)
        {
            MyBinaryTreeNode<T> parent;
            var node = this.FindWithParent(value, out parent);
            if (node == null)
            {
                return false;
            }

            // Case 1
            // Removed node has no right child.
            // In this case, promote the left child to the parent.
            if (node.Right == null)
            {
                if (parent == null)
                {
                    parent = node.Left;
                }
                else
                {
                    parent.Right = node.Left;
                }
            }
            else if (node.Right.Left == null)
            {
                // Case 2
                // Node to be removed right child has no left child
                // Promote left child to removed node position
                // Make left child new parent to left node of removed node.
                parent.Right = node.Right;
                node.Right.Left = node.Left;
            }
            else if (node.Right.Left != null)
            {
                // Case 3
                // Node to be removed right child has a left child
                // Promote right child's left-most child to the position of the node to be removed.

                var leftMost = node.Right.Left;
                while (leftMost.Left != null)
                {
                    leftMost = leftMost.Left;
                }
                parent.Right = leftMost;
                leftMost.Left = node.Left;
                leftMost.Right = node.Right;
                node.Right.Left = null;
            }

            this.Count--;
            return true;
        }

        public void InOrderTraversal(Action<T> action)
        {
            this.InOrderTraversal(action, this.Root);
        }

        private void InOrderTraversal(Action<T> action, MyBinaryTreeNode<T> node)
        {
            if (node != null)
            {
                this.InOrderTraversal(action, node.Left);
                action(node.Value);
                this.InOrderTraversal(action, node.Right);
            }
        }

        public void PreOrderTraversal(Action<T> action)
        {
            this.PreOrderTraversal(action, this.Root);
        }

        private void PreOrderTraversal(Action<T> action, MyBinaryTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                this.PreOrderTraversal(action, node.Left);
                this.PreOrderTraversal(action, node.Right);
            }
        }

        public void PostOrderTraversal(Action<T> action)
        {
            this.PostOrderTraversal(action, this.Root);
        }

        private void PostOrderTraversal(Action<T> action, MyBinaryTreeNode<T> node)
        {
            if (node != null)
            {
                this.PostOrderTraversal(action, node.Left);
                this.PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {        
            List<T> list = new List<T>();  
            this.InOrderTraversal((v) => 
            {
                list.Add(v);
            }, this.Root);
            foreach(var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
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