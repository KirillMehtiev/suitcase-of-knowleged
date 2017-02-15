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
            // arrange

            // act
            _linkedList.Prepend(1);
            _linkedList.Prepend(2);
            _linkedList.Prepend(3);

            // asset
            Assert.Equal(3, _linkedList.Count);
            Assert.Equal(3, _linkedList.First);
            Assert.Equal(1, _linkedList.Last);
        }

        [Fact]
        public void Append()
        {
            // arrange
            

            // act
            _linkedList.Append(1);
            _linkedList.Append(2);

            // asset
            Assert.Equal(2, _linkedList.Count);
            Assert.Equal(1, _linkedList.First);
            Assert.Equal(2, _linkedList.Last);
        }

        [Fact]
        public void InsertAtTheBeginnig()
        {
            // arrange
            _linkedList.Append(1);
            _linkedList.Append(2);

            // act
            _linkedList.InsertAt(0, 0);

            // asset
            Assert.Equal(3, _linkedList.Count);
            Assert.Equal(0, _linkedList.First);
        }

        [Fact]
        public void InsertAtTheMiddle()
        {
            // arrange
            _linkedList.Append(0);
            _linkedList.Append(2);
            _linkedList.Append(3);

            // act
            _linkedList.InsertAt(1, 1);

            // asset
            Assert.Equal(4, _linkedList.Count);
            Assert.Equal(1, _linkedList.Head.Next.Data);
        }

        [Fact]
        public void InsertAtTheEnd()
        {
            // arrange
            _linkedList.Append(0);
            _linkedList.Append(2);

            // act
            _linkedList.InsertAt(1, 1);

            // asset
            Assert.Equal(3, _linkedList.Count);
            Assert.Equal(1, _linkedList.Head.Next.Data);
        }

        [Fact]
        public void InsertToEmptyList()
        {
            // arrange
            
            // act
            _linkedList.InsertAt(0, 0);

            // asset
            Assert.Equal(1, _linkedList.Count);
            Assert.Equal(0, _linkedList.First);
            Assert.Equal(0, _linkedList.Last);
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
            Assert.Equal(0, linkedList.First);
            Assert.Equal(0, linkedList.Last);
        }
    }
}