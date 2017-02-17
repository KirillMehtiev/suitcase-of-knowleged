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
            var tree = new BinarySearchTree<int>();

            var root  = tree.InsertNode(null, 5);
            tree.InsertNode(root, 3);
            tree.InsertNode(root, 7);
            tree.InsertNode(root.LeftNode, 4);
            tree.InsertNode(root.RightNode, 6);
            tree.InsertNode(root.RightNode, 9);
            tree.InsertNode(root.RightNode.LeftNode, 8);

            var result = tree.Traverse(root, TraverseOrder.Inorder);

            foreach (var item in result)
                Console.Write(item);

            Console.ReadKey();
        }
    }
}
    