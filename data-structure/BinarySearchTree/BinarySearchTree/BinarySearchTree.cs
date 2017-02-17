using System;
using System.Collections.Generic;
using System.Xml.XPath;

namespace BinarySearchTree
{
    enum TraverseOrder
    {
        Preorder,
        Inorder,
        Postorder
    }

    class BinarySearchTree<T> where T : IComparable<T>
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

        public T[] Traverse(TreeNode<T> root, TraverseOrder order = TraverseOrder.Preorder)
        {
            if (root == null) return new T[0];

            var result = new List<T>();

            switch (order)
            {
                case TraverseOrder.Inorder:
                    {
                        result.AddRange(Traverse(root.LeftNode, order));
                        result.Add(root.Value);
                        result.AddRange(Traverse(root.RightNode, order));
                        break;
                    }
                case TraverseOrder.Postorder:
                    {
                        result.AddRange(Traverse(root.LeftNode, order));
                        result.AddRange(Traverse(root.RightNode, order));
                        result.Add(root.Value);
                        break;
                    }
                default:
                    {
                        result.Add(root.Value);
                        result.AddRange(Traverse(root.LeftNode, order));
                        result.AddRange(Traverse(root.RightNode, order));
                        break;
                    }
            }

            return result.ToArray();
        }
    }
}