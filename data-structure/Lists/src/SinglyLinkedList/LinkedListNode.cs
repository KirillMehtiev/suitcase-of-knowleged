using System;

namespace SinglyLinkedList
{
    class LinkedListNode<T> : IDisposable
    {
        private T _data;
        private LinkedListNode<T> _next;

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public LinkedListNode<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public LinkedListNode()
        {
            _data = default(T);
            _next = null;
        }

        public LinkedListNode(T data) : this()
        {
            _data = data;
        }

        public LinkedListNode(T data, LinkedListNode<T> next) : this(data)
        {
            _next = next;
        }

        public void Dispose()
        {
            _data = default(T);
            _next = null;
        }
    }
}