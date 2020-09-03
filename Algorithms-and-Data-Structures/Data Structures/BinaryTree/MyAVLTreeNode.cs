namespace Algorithms_and_Data_Structures
{
    using System;

    public class MyAVLTreeNode<T> : IComparable<T> 
    where T : IComparable<T>
{
    private MyAVLTreeNode<T> left;

    private MyAVLTreeNode<T> right;

    private MyAVLTree<T> tree;

    #region Constructors
    public MyAVLTreeNode(MyAVLTree<T> tree, T value) 
    {
        this.tree = tree;
        this.Value = value;
    }
    #endregion

    #region Properties
    
    public T Value { get; set;}
    
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

    public MyAVLTreeNode<T> Parent {get; set;}

    // Used only in post order traversal
    public bool Visited {get; set;}

    public int CompareTo(T other) => this.Value.CompareTo(other);


    // Distance from current node to furthest child node.
    public int LeftHeight => this.MaxChildHeight(this.Left);

    // Distance from current node to furthest child node.
    public int RightHeight => this.MaxChildHeight(this.Right);

    public int BalanceFactor => this.RightHeight - this.LeftHeight;

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

    private int MaxChildHeight(MyAVLTreeNode<T> node)
    {
        if (node != null)
        {
            return 1 + Math.Max(this.MaxChildHeight(node.Left), this.MaxChildHeight(node.Right));
        }
        return 0;
    }

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

    public void LeftRightRotation()
    {
        var newRoot = this.RightRotation();
        this.RightRotation();
        newRoot.LeftRotation();
    }

    public void RightLeftRotation()
    {
        this.Left.LeftRotation();
        this.RightRotation();
    }

    #endregion

    #region Enums

    public enum TreeState
    {
        LeftHeavy,
        RightHeavy,
        Balanced
    }

    #endregion
}
}