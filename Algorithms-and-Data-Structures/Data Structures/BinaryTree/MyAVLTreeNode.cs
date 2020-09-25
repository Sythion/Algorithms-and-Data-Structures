namespace Algorithms_and_Data_Structures
{
    using System;

    /// <summary>
    /// The node to be used in the MyAVLTree class.
    /// </summary>
    /// <typeparam name="T">The type of value used in the tree.</typeparam>
    public class MyAVLTreeNode<T> : IComparable<T> where T : IComparable<T>
    {
        /// <summary>
        /// A reference to the left child node.
        /// </summary>
        private MyAVLTreeNode<T> left;

        /// <summary>
        /// A reference to the right child node.
        /// </summary>
        private MyAVLTreeNode<T> right;

        /// <summary>
        /// A reference to the MyAVLTree class to which the node belongs.
        /// </summary>
        private MyAVLTree<T> tree;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MyAVLTreeNode class.
        /// </summary>
        /// <param name="tree">A reference to the MyAVLTree class to which the node belongs.</param>
        /// <param name="value">The value to store in the node.</param>
        public MyAVLTreeNode(MyAVLTree<T> tree, T value) 
        {
            this.tree = tree;
            this.Value = value;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the value of the node.
        /// </summary>
        /// <value></value>        
        public T Value { get; set;}
        
        /// <summary>
        /// Gets or sets the left child node.
        /// </summary>
        /// <value>The value of the node.</value>
        public MyAVLTreeNode<T> Left 
        { 
            get
            {
                return this.left;
            }
            set
            {
                this.left = value;
                if (this.left != null)
                {
                    this.left.Parent = this;
                }
            }     
        }
        
        /// <summary>
        /// Gets or sets the right child node.
        /// </summary>
        /// <value>The value of the node.</value>
        public MyAVLTreeNode<T> Right 
        { 
            get
            {
                return this.right;
            }
            set
            {
                this.right = value;
                if (this.right != null)
                {
                    this.right.Parent = this;
                }
            }     
        }

        /// <summary>
        /// Gets or sets the parent node.
        /// </summary>
        /// <value>The value of the node.</value>
        public MyAVLTreeNode<T> Parent {get; set;}

        // Used only in post order traversal
        public bool Visited {get; set;}

        /// <summary>
        /// Compares the value of this node to the value provided.
        /// </summary>
        /// <param name="other">The value to which to compare.</param>
        /// <returns></returns>
        public int CompareTo(T other) => this.Value.CompareTo(other);

        /// <summary>
        /// The distance from the current node to the furthest left child node.
        /// </summary>
        /// <returns>Returns the height of the furthest left child node.</returns>
        public int LeftHeight => this.MaxChildHeight(this.Left);

        /// <summary>
        /// The distance from the current node to the furthest right child node.
        /// </summary>
        /// <returns>Returns the height of the furthest right child node.</returns>
        public int RightHeight => this.MaxChildHeight(this.Right);

        /// <summary>
        /// The difference in right height and left height.
        /// </summary>
        public int BalanceFactor => this.RightHeight - this.LeftHeight;

        /// <summary>
        /// The state of the tree with the present node as the root node.
        /// </summary>
        /// <value>A TreeState value</value>
        public TreeState State
        {
            get
            {
                if (this.BalanceFactor > 0)
                {
                    return TreeState.RightHeavy;
                }
                else if (this.BalanceFactor < 0)
                {
                    return TreeState.LeftHeavy;
                }
                else
                {
                    return TreeState.Balanced;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the longest distance between the provided node and its child nodes.
        /// </summary>
        /// <param name="node">The node for which to retrieve the max height.</param>
        /// <returns>Returns the max height.</returns>
        private int MaxChildHeight(MyAVLTreeNode<T> node)
        {
            if (node != null)
            {
                return 1 + Math.Max(this.MaxChildHeight(node.Left), this.MaxChildHeight(node.Right));
            }
            return 0;
        }

        /// <summary>
        /// Balances the tree starting at this node.
        /// </summary>
        public void Balance()
        {
            if (this.State == TreeState.RightHeavy)
            {
                if (this.Right != null && this.Right.BalanceFactor < 0)
                {
                    this.LeftRightRotation();
                }
                else
                {
                    this.LeftRotation();
                }
            }
            else if (this.State == TreeState.LeftHeavy)
            {
                if (this.Left != null && this.Left.BalanceFactor > 0)
                {
                    this.RightLeftRotation();
                }
                else
                {
                    this.RightRotation();
                }
            }
        }

        /// <summary>
        /// Changes the root node and updates all references between the root reference, parent node, and new root.
        /// </summary>
        /// <param name="newRoot">The node to make the new root.</param>
        private void SetRoot(MyAVLTreeNode<T> newRoot)
        {
            newRoot.Parent = this.Parent;
            if (this.Parent == null)
            {
                this.tree.Root = newRoot;
            }
            else
            {
                if (this.Parent.Left == this)
                {
                    this.Parent.Left = newRoot;
                }
                else if (this.Parent.Right == this)
                {
                    this.Parent.Right = newRoot;
                }
            }
        }

        /// <summary>
        /// Performs a left rotation around the current node.
        /// </summary>
        /// <returns>Returns the new root node for that section.</returns>
        public MyAVLTreeNode<T> LeftRotation()
        {
            MyAVLTreeNode<T> newRoot = null;
            if (this.MaxChildHeight(this) > 1)
            {
                if (this.Right != null)
                {
                    newRoot = this.Right;
                    this.SetRoot(newRoot);
                    this.Right = newRoot?.Left;
                    newRoot.Left = this;
                }
            }
            return newRoot;
        }

        /// <summary>
        /// Performs a right rotation around the current node.
        /// </summary>
        /// <returns>Returns the new root node for that section.</returns>
        public MyAVLTreeNode<T> RightRotation()
        {
            MyAVLTreeNode<T> newRoot = null;
            if (this.MaxChildHeight(this) > 1)
            {
                if (this.Left != null)
                {
                    newRoot = this.Left;
                    this.SetRoot(newRoot);
                    this.Left = newRoot?.Right;
                    newRoot.Right = this;
                }
            } 
            return newRoot; 
        }

        /// <summary>
        /// Performs a left-right rotation around the current node.
        /// </summary>
        public void LeftRightRotation()
        {
            var newRoot = this.RightRotation();
            this.RightRotation();
            newRoot.LeftRotation();
        }

        /// <summary>
        /// Performs a right-left rotation around the current node.
        /// </summary>
        public void RightLeftRotation()
        {
            this.Left.LeftRotation();
            this.RightRotation();
        }

        #endregion

        #region Enums

        /// <summary>
        /// An enum defining the tree states.
        /// </summary>
        public enum TreeState
        {
            LeftHeavy,
            RightHeavy,
            Balanced
        }

        #endregion
    }
}