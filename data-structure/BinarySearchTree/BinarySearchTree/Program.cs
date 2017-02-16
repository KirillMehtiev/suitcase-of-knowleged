using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //var node5 = new TreeNode<int>(5);
            //var node3 = new TreeNode<int>(3);
            //var node7 = new TreeNode<int>(7);
            //var node4 = new TreeNode<int>(4);
            //var node6 = new TreeNode<int>(6);
            //var node9 = new TreeNode<int>(9);
            //var node8 = new TreeNode<int>(9);

            //node5.LeftNode = node3;
            //node5.RightNode = node7;

            //node3.RightNode = node4;

            //node7.LeftNode = node6;
            //node7.RightNode = node9;

            //node6.RightNode = node8;

            var tree = new BinaryTree<int>();

            var root  = tree.InsertNode(null, 5);
            tree.InsertNode(root, 3);
            tree.InsertNode(root, 7);
            tree.InsertNode(root.LeftNode, 4);
            tree.InsertNode(root.RightNode, 6);
            tree.InsertNode(root.RightNode, 9);
            tree.InsertNode(root.RightNode.LeftNode, 8);

            //var isContans8 = tree.Contains(root, 9);
            //Console.WriteLine(isContans8);
            tree.Traverse(root);

            Console.ReadKey();
        }
    }
}
    