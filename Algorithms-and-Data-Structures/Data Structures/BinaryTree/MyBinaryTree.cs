namespace Algorithms_and_Data_Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Custom binary tree class.
    /// Best-case time complexity for a binary tree search is O(log(N)) if the tree is balanced.  
    /// All binary operations will be log(N) for a single search.  This is because at each level of the tree, we will require at most 1 additional comparison.
    /// So for a binary tree with 16 nodes (nodes without children) we will require at most 4 comparisons which equals the height of the tree (starting at 0).
    /// Worst-case time complexity for a binary tree search is O(N) if the tree is significantly unbalanced. 
    /// This is because if it is unbalanced enough, it will behave like a linked list.
    /// </summary>
    /// <typeparam name="T">The generic type</typeparam>
    public class MyBinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
#region Fields
#endregion

#region Properties

        /// <summary>
        /// Gets or sets the root node.
        /// </summary>
        /// <value>Gets or sets the root node.</value>
        public MyBinaryTreeNode<T> Root { get; set; }
        
        /// <summary>
        /// Gets the number of nodes in the tree.
        /// </summary>
        /// <value>Gets the number of nodes in the tree.</value>
        public int Count { get; private set;}

#endregion

#region Methods

        /// <summary>
        /// Removes all nodes from the tree.
        /// </summary>
        public void Clear()
        {
            this.Count = 0;
            this.Root = null;
        }
        
        /// <summary>
        /// Adds the provided value to the tree.
        /// </summary>
        /// <param name="value">The value of the item to add.</param>
        public void Add(T value)
        {
            if (this.Root == null)
            {
                this.Root = new MyBinaryTreeNode<T>(value);
            }
            else
            {
                this.Add(this.Root, value);
            }

            this.Count++;
        }

        /// <summary>
        /// Recursively adds the value to the tree, beginning with the provided node.
        /// </summary>
        /// <param name="node">The node to first compare when adding values.</param>
        /// <param name="value">The value to add.</param>
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

        /// <summary>
        /// Returns a value indicating whether the tree contains the provided value or not.
        /// </summary>
        /// <param name="value">The value to find.</param>
        /// <returns>Returns a value indicating whether the tree contains the provided value or not.</returns>
        public bool Contains(T value)
        {
            MyBinaryTreeNode<T> parent;
            return this.FindWithParent(value, out parent) != null;
        }

        /// <summary>
        /// Searches the tree for the provided value and also gets the value's parent.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <param name="parent">The parent of the value, if it is found.</param>
        /// <returns>Returns the MyBinaryTreeNode with the matching value.</returns>
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

        /// <summary>
        /// Removes the node with the provided value.
        /// </summary>
        /// <param name="value">The value of the node to remove.</param>
        /// <returns>Returns a value indicating whether the node was removed or not.</returns>
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
            return true;
        }

        /// <summary>
        /// Traverses the tree in value order.
        /// </summary>
        /// <param name="action">The action object necessary for recursive traversal.</param>
        public void InOrderTraversal(Action<T> action)
        {
            this.InOrderTraversal(action, this.Root);
        }

        /// <summary>
        /// Traverses the tree in value order.
        /// </summary>
        /// <param name="action">The action object necessary for recursive traversal.</param>
        /// <param name="node">The node to start traversing.</param>
        private void InOrderTraversal(Action<T> action, MyBinaryTreeNode<T> node)
        {
            if (node != null)
            {
                this.InOrderTraversal(action, node.Left);
                action(node.Value);
                this.InOrderTraversal(action, node.Right);
            }
        }

        /// <summary>
        /// Traverses the tree in pre-order.
        /// </summary>
        /// <param name="action">The action object necessary for recursive traversal.</param>
        public void PreOrderTraversal(Action<T> action)
        {
            this.PreOrderTraversal(action, this.Root);
        }

        /// <summary>
        /// Traverses the tree in pre-order.
        /// </summary>
        /// <param name="action">The action object necessary for recursive traversal.</param>
        /// <param name="node">The node to start traversing.</param>
        private void PreOrderTraversal(Action<T> action, MyBinaryTreeNode<T> node)
        {
            if (node != null)
            {
                action(node.Value);
                this.PreOrderTraversal(action, node.Left);
                this.PreOrderTraversal(action, node.Right);
            }
        }

        /// <summary>
        /// Traverses the tree in post-order.
        /// </summary>
        /// <param name="action">The action object necessary for recursive traversal.</param>
        public void PostOrderTraversal(Action<T> action)
        {
            this.PostOrderTraversal(action, this.Root);
        }

        /// <summary>
        /// Traverses the tree in post-order.
        /// </summary>
        /// <param name="action">The action object necessary for recursive traversal.</param>
        /// <param name="node">The node to start traversing.</param>
        private void PostOrderTraversal(Action<T> action, MyBinaryTreeNode<T> node)
        {
            if (node != null)
            {
                this.PostOrderTraversal(action, node.Left);
                this.PostOrderTraversal(action, node.Right);
                action(node.Value);
            }
        }

        /// <summary>
        /// Performs in-order traversal without recursion. (left child, node, right child).
        /// </summary>
        /// <returns>Returns an Enumerator object.</returns>
        public IEnumerator<T> InOrderTraversalNoRecurse()
        {
            var stack = new Stack<MyBinaryTreeNode<T>>();
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

        /// <summary>
        /// Performs pre-order traversal without recursion (node, left child, right child).
        /// </summary>
        /// <returns>Returns an enumerator.</returns>
        public IEnumerator<T> PreOrderTraversalNoRecurse()
        {
            /// This is very similar to InOrderTraversalNoRecurse.  The only change is where the values are returned.
            var stack = new Stack<MyBinaryTreeNode<T>>();
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

        /// <summary>
        /// Performs pre-order traversal without using recursion (left child, right child, node).
        /// </summary>
        /// <returns>Returns an Enumerator.</returns>
        public IEnumerator<T> PostOrderTraversalNoRecurse()
        {
            // This one is more 'complicated' than the other two.  It's complicated in that it was a lot different even though 
            // the implementation actually ends up simpler. Uses a 'Visited' flag not used in the other two methods.

            var stack = new Stack<MyBinaryTreeNode<T>>();
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

        /// <summary>
        /// Implementation of IEnumerable.
        /// </summary>
        /// <returns>Returns an Enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {        
            return this.InOrderTraversalNoRecurse();
        }

        /// <summary>
        /// Implementation of IEnumerable.
        /// </summary>
        /// <returns>Returns an Enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }

#endregion

#region Classes

    /// <summary>
    /// A node class to be used with the MyBinaryTree class.
    /// </summary>
    /// <typeparam name="TNode">The value to use with the MyBinaryTreeNode.</typeparam>
    public class MyBinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        /// <summary>
        /// Initializes a new instance of the MyBinaryTreeNode class.
        /// </summary>
        /// <param name="value">The value to supply the node.</param>
        public MyBinaryTreeNode(TNode value)
        {
            this.Value = value;
        }
        
        /// <summary>
        /// Gets or sets the value of the node.
        /// </summary>
        /// <value></value>
        public TNode Value { get; set;}
        
        /// <summary>
        /// Gets or sets the left child node.
        /// </summary>
        /// <value></value>
        public MyBinaryTreeNode<TNode> Left { get; set; }
        
        /// <summary>
        /// Gets or sets the right child node.
        /// </summary>
        /// <value></value>
        public MyBinaryTreeNode<TNode> Right { get; set; }

        // Used only in post order traversal
        public bool Visited {get; set;}

        /// <summary>
        /// Implementation of IComparable.
        /// </summary>
        /// <param name="other">The other object to compare this one's value to.</param>
        /// <returns>Returns an integer indicating if the value was less than (-1), equal (0), or greater than (1) the "other" value.</returns>
        public int CompareTo(TNode other)
        {
            return this.Value.CompareTo(other);
        }
    }

#endregion
}