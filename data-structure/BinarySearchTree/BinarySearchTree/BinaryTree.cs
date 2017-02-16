using System;

namespace BinarySearchTree
{
    class BinaryTree<T> where T : IComparable<T>, IEquatable<T>
    {
        public TreeNode<T> InsertNode(TreeNode<T> parent, T childValue)
        {
            if (parent == null)
            {
                parent = new TreeNode<T>(childValue);
            }
            else if (parent.Value.CompareTo(childValue) < 0)
            {
                parent.LeftNode = new TreeNode<T>(childValue);
            }
            else
            {
                parent.RightNode = new TreeNode<T>(childValue);
            }

            return parent;
        }

        public void Traverse(TreeNode<T> root)
        {
            if(root == null)  return;

            Traverse(root.LeftNode);
            Traverse(root.RightNode);
        }

        public bool Contains(TreeNode<T> root, T nodeValue)
        {
            bool result = root.Value.Equals(nodeValue);

            if (root.LeftNode != null)
            {
                result = Contains(root.LeftNode, nodeValue);
            }
            else if (root.RightNode != null)
            {
                result = Contains(root.RightNode, nodeValue);
            }

            return result;
        }
    }
}