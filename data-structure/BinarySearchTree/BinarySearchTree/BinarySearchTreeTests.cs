using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BinarySearchTree
{
    public class BinarySearchTreeTests
    {
        private readonly BinarySearchTree<int> _tree = new BinarySearchTree<int>();
        private readonly TreeNode<int> _root;

        public BinarySearchTreeTests()
        {
            _root = _tree.InsertNode(null, 5);
            _tree.InsertNode(_root, 3);
            _tree.InsertNode(_root, 7);
            _tree.InsertNode(_root.LeftNode, 4);
            _tree.InsertNode(_root.RightNode, 6);
            _tree.InsertNode(_root.RightNode, 9);
            _tree.InsertNode(_root.RightNode.LeftNode, 8);
        }

        [Fact]
        public void TraverseDefaultPreorder()
        {
            var preordered = new[] { 5, 3, 4, 7, 6, 8, 9 };
            var result = _tree.Traverse(_root);

            Assert.Equal(preordered, result);
        }

        [Fact]
        public void TraverseInorder()
        {
            var inordered = new[] { 3, 4, 5, 6, 8, 7, 9 };
            var result = _tree.Traverse(_root, TraverseOrder.Inorder);

            Assert.Equal(inordered, result);
        }

        [Fact]
        public void TraversePreorder()
        {
            var postodered = new[] { 4, 3, 8, 6, 9, 7, 5 };
            var result = _tree.Traverse(_root, TraverseOrder.Postorder);

            Assert.Equal(postodered, result);
        }
    }
}
