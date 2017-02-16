namespace BinarySearchTree
{
    class TreeNode<T>
    {
        public TreeNode(T value): this(null, null, value) { }
        
        public TreeNode(TreeNode<T> leftNode, TreeNode<T> rightNode, T value)
        {
            LeftNode = leftNode;
            RightNode = rightNode;
            Value = value;
        }

        public TreeNode<T> LeftNode { get; set; }
        public TreeNode<T> RightNode { get; set; }
        public T Value { get; }
    }
}