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

    private void Balance()
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

    public void LeftRotation()
    {
        throw new NotImplementedException();
    }

    public void RightRotation()
    {
        if (this.MaxChildHeight(this) > 1)
        {
            var newRoot = this.Left;
            // if this node is root
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

            this.Left = newRoot.Right;
            newRoot.Right = this;
        }

        
        /*
        // Promote left child to root
        this.Left.Parent = this.Parent;
        this.Parent = this.Left;

        // Move right child of new root
        this.left = this.Parent.Right;
        this.Parent.Right = this;      
        */   
    }

    public void LeftRightRotation()
    {
        throw new NotImplementedException();
    }

    public void RightLeftRotation()
    {
        throw new NotImplementedException();
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