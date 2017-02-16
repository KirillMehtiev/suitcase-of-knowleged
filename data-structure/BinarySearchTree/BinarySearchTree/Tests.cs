using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BinarySearchTree
{
    public class Tests
    {
        private readonly BinaryTree<int> _tree;
        private readonly TreeNode<int> _root;

        public Tests()
        {
            _tree = new BinaryTree<int>();

            _root = _tree.InsertNode(null, 5);
            _tree.InsertNode(_root, 3);
            _tree.InsertNode(_root, 7);
            _tree.InsertNode(_root.LeftNode, 4);
            _tree.InsertNode(_root.RightNode, 6);
            _tree.InsertNode(_root.RightNode, 9);
            _tree.InsertNode(_root.RightNode.LeftNode, 8);
        }

        [Fact]
        public void NotContains()
        {
            Assert.False(_tree.Contains(_root, 10));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        public void ContainsAll(int value)
        {
            Assert.True(_tree.Contains(_root, value));
        }

    }
}
