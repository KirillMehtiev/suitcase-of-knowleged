using System.Threading;
using Xunit;

namespace SinglyLinkedList
{
    public class LinkedListTests
    {
        private readonly LinkedList<int> _linkedList;

        public LinkedListTests()
        {
            _linkedList = new LinkedList<int>();
        }

        [Fact]
        public void Prepend()
        {
            _linkedList.Prepend(1);
            _linkedList.Prepend(2);
            _linkedList.Prepend(3);

            Assert.Equal(3, _linkedList.Count);
            Assert.Equal(3, _linkedList.Head.Data);
        }

        [Fact]
        public void Append()
        {
            _linkedList.Append(1);
            _linkedList.Append(2);

            Assert.Equal(2, _linkedList.Count);
            Assert.Equal(2, _linkedList.Head.Next.Data);
        }

        [Fact]
        public void InsertAtTheBeginnig()
        {
            _linkedList.Append(1);
            _linkedList.Append(2);
            _linkedList.InsertAt(0, 0);

            Assert.Equal(3, _linkedList.Count);
            Assert.Equal(0, _linkedList.Head.Data);
        }

        [Fact]
        public void InsertAtTheMiddle()
        {
            _linkedList.Append(0);
            _linkedList.Append(2);
            _linkedList.Append(3);
            _linkedList.InsertAt(1, 1);

            Assert.Equal(4, _linkedList.Count);
            Assert.Equal(1, _linkedList.Head.Next.Data);
        }

        [Fact]
        public void InsertAtTheEnd()
        {
            _linkedList.Append(0);
            _linkedList.InsertAt(_linkedList.Count, 1);

            Assert.Equal(2, _linkedList.Count);
            Assert.Equal(1, _linkedList.Head.Next.Data);
        }

        [Fact]
        public void InsertToEmptyList()
        {
            _linkedList.InsertAt(0, 0);

            Assert.Equal(1, _linkedList.Count);
            Assert.Equal(0, _linkedList.Head.Data);
        }

        [Fact(Skip = "Method has not been implemented yet.")]
        public void RemoveAt()
        {
            // arrange
            var linkedList = new LinkedList<int>();
            linkedList.Append(1);
            linkedList.Append(2);

            // act
            linkedList.RemoveAt(1);


            // asset
            Assert.Equal(0, linkedList.Head.Data);
        }
    }
}