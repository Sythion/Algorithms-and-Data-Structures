namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyAVLTree<T> : IEnumerable<T> where T : IComparable<T>
    {
#region Fields

#endregion

#region Constructors
    public MyAVLTree(bool autoBalance = true) => this.AutoBalance = autoBalance;

#endregion

#region Properties
        public MyAVLTreeNode<T> Root { get; set; }
        
        public int Count { get; private set;}

        public bool AutoBalance {get; set;}

#endregion

#region Methods

        public void Clear()
        {
            this.Count = 0;
            this.Root = null;
        }

        public void AddRange(params T[] items)
        {
            foreach(var item in items)
            {
                this.Add(item);
            }
        }
        
        public void Add(T item)
        {
            if (this.Root == null)
            {
                this.Root = new MyAVLTreeNode<T>(this, item);
            }
            else
            {
                this.Add(this.Root, item);
            }

            this.Count++;
        }

        private void Add(MyAVLTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new MyAVLTreeNode<T>(this, value);
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
                    node.Right = new MyAVLTreeNode<T>(this, value);
                }
                else
                {
                    this.Add(node.Right, value);
                }
            }

            this.BalanceNode(node);
        }

        private void BalanceNode(MyAVLTreeNode<T> node)
        {
            if (this.AutoBalance && (node.BalanceFactor > 1 || node.BalanceFactor < -1))
            {
                node.Balance();
            }
        }

        public bool Contains(T value)
        {
            MyAVLTreeNode<T> parent;
            return this.FindWithParent(value, out parent) != null;
        }

        private MyAVLTreeNode<T> FindWithParent(T value, out MyAVLTreeNode<T> parent)
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
            MyAVLTreeNode<T> parent;
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
                // if root node...
                if (parent == null)
                {
                    this.Root = node.Left;
                }
                else
                {
                    // we don't know on what side of the parent the node to be removed is on.
                    // we need to check the value of the node to be removed against its parent.
                    if (node.Value.CompareTo(parent.Value) < 0)
                    {
                        parent.Left = node.Left;
                    }
                    else if (node.Value.CompareTo(parent.Value) > 0)
                    {
                        parent.Right = node.Left;
                    }

                    // TODO: What about if the nodes are equal???
                }
            }
            else if (node.Right.Left == null)
            {
                // Case 2
                // Node to be removed right child has no left child
                // Promote left child to removed node position
                // Make left child new parent to left node of removed node.

                // If parent is null, then the node is the root node.  Just promote right.
                if (parent == null)
                {
                    this.Root = node.Right;
                }
                else
                {
                    // Check if node is to right or left of parent again.
                    if (node.Value.CompareTo(parent.Value) < 0)
                    {
                        parent.Left = node.Right;
                    }
                    else if (node.Value.CompareTo(parent.Value) > 0)
                    {
                        parent.Right = node.Right;
                    }
                }
            }
            else if (node.Right.Left != null)
            {
                // Case 3
                // Node to be removed right child has a left child
                // Promote right child's left-most child to the position of the node to be removed.

                var leftMostParent = node.Right;
                var leftMost = node.Right.Left;
                while (leftMost.Left != null)
                {
                    leftMostParent = leftMost;
                    leftMost = leftMost.Left;
                }

                if (parent == null)
                {
                    this.Root = leftMost;
                }
                else
                {
                    // Figure out if node is to the left or right of parent
                    if (node.Value.CompareTo(parent.Value) < 0)
                    {
                        parent.Left = leftMost;
                    }
                    else if (node.Value.CompareTo(parent.Value) > 0)
                    {
                        parent.Right = leftMost;
                    }
                }

                // Update subtree.
                leftMostParent.Left = leftMost.Right;
                leftMost.Left = node.Left;
                leftMost.Right = node.Right;
            }

            this.Count--;

            // Auto-balancing
            if (parent == null)
            {
                this.Root.Balance();
            }
            else
            {
                parent.Balance();
            }

            return true;
        }

        public void InOrderTraversal(Action<T> action)
        {
            this.InOrderTraversal(action, this.Root);
        }

        private void InOrderTraversal(Action<T> action, MyAVLTreeNode<T> node)
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

        private void PreOrderTraversal(Action<T> action, MyAVLTreeNode<T> node)
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

        private void PostOrderTraversal(Action<T> action, MyAVLTreeNode<T> node)
        {
            if (node != null)
            {
                this.PostOrderTraversal(action, node.Left);
                this.PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }

        
        public IEnumerator<T> InOrderTraversalNoRecurse()
        {
            var stack = new Stack<MyAVLTreeNode<T>>();
            var current = this.Root;
            bool goLeft = true;

            // Push head to stack
            stack.Push(current);

            while (stack.Count > 0)
            {
                if (goLeft)
                {
                    // Move everything except left-most node to stack.
                    while (current.Left != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }
                }

                yield return current.Value;
                
                // Go right now.
                goLeft = false;

                if (current.Right != null)
                {
                    current = current.Right;
                    goLeft = true;
                }
                else
                {
                    current = stack.Pop();
                    goLeft = false;
                }
            }
        }

        // This is very similar to InOrderTraversalNoRecurse.  The only change is where the values are returned.
        public IEnumerator<T> PreOrderTraversalNoRecurse()
        {
            var stack = new Stack<MyAVLTreeNode<T>>();
            var current = this.Root;
            bool goLeft = true;

            // Push head to stack
            stack.Push(current);
            yield return current.Value;

            while (stack.Count > 0)
            {
                if (goLeft)
                {
                    // Move everything except left-most node to stack.
                    while (current.Left != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                        yield return current.Value;
                    }
                }
                
                // Go right now.
                goLeft = false;

                if (current.Right != null)
                {
                    current = current.Right;
                    yield return current.Value;
                    goLeft = true;
                }
                else
                {
                    current = stack.Pop();
                    goLeft = false;
                }
            }
        }

        // This one is more 'complicated' than the other two.  It's complicated in that it was a lot different even though 
        // the implementation actually ends up simpler. Uses a 'Visited' flag not used in the other two methods.
        public IEnumerator<T> PostOrderTraversalNoRecurse()
        {
            var stack = new Stack<MyAVLTreeNode<T>>();
            var current = this.Root;

            // Push head to stack
            stack.Push(current);

            while (stack.Count > 0)
            {
                // Peek to get current node.
                current = stack.Peek();
                // Go left
                if (current.Left != null && !current.Left.Visited)
                {
                    stack.Push(current.Left);
                }
                else
                {
                    // Go right
                    if (current.Right != null && !current.Right.Visited)
                    {
                        stack.Push(current.Right);
                    }
                    else
                    {
                        // Go to previous node by popping off stack.
                        // Then peek at the top of the stack to 
                        yield return current.Value;
                        current.Visited = true;
                        stack.Pop();
                    }
                }
                
            }
        }

        public IEnumerator<T> GetEnumerator()
        {        
            return this.PreOrderTraversalNoRecurse();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        #endregion

    }
}