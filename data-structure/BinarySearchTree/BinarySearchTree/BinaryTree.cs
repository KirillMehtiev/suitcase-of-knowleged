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
            else if (childValue.CompareTo(parent.Value) < 0)
            {
                parent.LeftNode = InsertNode(parent.LeftNode, childValue);
            }
            else
            {
                parent.RightNode = InsertNode(parent.RightNode, childValue);
            }

            return parent;
        }

        public void Traverse(TreeNode<T> root)
        {
            if(root == null)  return;

            Console.WriteLine(root.Value);

            Traverse(root.LeftNode);
            Traverse(root.RightNode);
        }

        public bool Contains(TreeNode<T> root, T nodeValue)
        {
            if (root != null)
            {
                if (root.Value.Equals(nodeValue)) return true;

                if (root.LeftNode != null)
                    Contains(root.LeftNode, nodeValue);

                if (root.RightNode != null)
                    Contains(root.RightNode, nodeValue);
            }

            return false;

        }
    }
}