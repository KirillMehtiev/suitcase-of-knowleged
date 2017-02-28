using System;
using System.Collections;
using System.Collections.Generic;
using Xunit.Sdk;

namespace SinglyLinkedList
{
    class LinkedList<T> : IEnumerable<T>
    {
        private int _count = 0;
        private LinkedListNode<T> _firstNode;
        private LinkedListNode<T> _lastNode;

        public int Count => _count;
        public LinkedListNode<T> Head => First;
        public bool IsEmpty => _count == 0;

        private LinkedListNode<T> First
        {
            get { return _firstNode; }
            set { _firstNode = value; }
        }

        private LinkedListNode<T> Last
        {
            get
            {
                var last = First;

                if (last != null)
                {
                    while (last.Next != null)
                    {
                        last = last.Next;
                    }
                }

                return last;
            }
            set { _lastNode = value; }
        }

        /// <summary>
        /// Inserts the specified data at the beginning of the list.
        /// </summary>
        /// <param name="data">The data value to be inserted to the list.</param>
        public void Prepend(T data)
        {
            if (data == null) throw new ArgumentNullException();

            var item = new LinkedListNode<T>(data, _firstNode);

            if (IsEmpty)
            {
                First = item;
            }
            else if (_count > 0)
            {
                item.Next = First;
                First = item;
            }
            else
            {
                throw new Exception($"Can not prepend new item. Count = {_count}");
            }

            IncreaseCount(1);
        }

        /// <summary>
        /// Inserts the specified data at the end of the list.
        /// </summary>
        /// <param name="data">The data value to be inserted to the list.</param>
        public void Append(T data)
        {
            if (data == null) throw new ArgumentNullException();

            var item = new LinkedListNode<T>(data);

            if (IsEmpty)
            {
                First = item;
            }
            else if (_count > 0)
            {
                var last = Last;

                last.Next = item;
                Last = item;
            }
            else
            {
                throw new Exception($"Can not append new item. Count = {_count}");
            }

            IncreaseCount(1);
        }


        /// <summary>
        /// Inserts the specified data based on index at the list.
        /// </summary>
        /// <param name="data">The data value to be inserted to the list.</param>
        /// <param name="index">Index for data value to be inserted to the list.</param>
        public void InsertAt(T data, int index)
        {
            if (data == null) throw new ArgumentNullException();
            if (index < 0 || index > Count) throw new ArgumentOutOfRangeException("Index out of range!");

            if (index == 0)
            {
                Prepend(data);
            }
            else if (index == Count)
            {
                Append(data);
            }
            else
            {
                var itemToBeInserted = new LinkedListNode<T>(data);
                var counter = 0;

                var current = First;

                while (counter < index)
                {
                    if ((counter + 1) == index)
                    {
                        itemToBeInserted.Next = current.Next;
                        current.Next = itemToBeInserted;
                        break;
                    }

                    counter++;
                }

                IncreaseCount(1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            _count = 0;
            _firstNode = _lastNode = null;
        }

        public T GetAt(int index)
        {
            if (index < 0 && index < _count) throw new ArgumentOutOfRangeException("Index out of range!");

            var counter = 0;
            var current = _firstNode;
            var itemToBeReturned = default(T);

            while (counter < index)
            {
                if ((counter + 1) == index)
                {
                    itemToBeReturned = current.Next.Data;
                }
                counter++;
            }

            return itemToBeReturned;
        }

        public T[] ToArray()
        {
            T[] result = new T[_count];
            var current = _firstNode;

            for (int i = 0; i < _count; i++)
            {
                result[i] = current.Data;
                current = current.Next;
            }

            return result;
        }

        public List<T> ToList()
        {
            List<T> result = new List<T>(_count);
            var current = _firstNode;

            for (int i = 0; i < _count; i++)
            {
                result.Add(current.Data);
                current = current.Next;
            }

            return result;
        }

        private void IncreaseCount(int increaseNumber)
        {
            _count += increaseNumber;
        }
        
        private void DecreaseCount(int decreaseNumber)
        {
            _count += decreaseNumber;
        }

        // interface implimentation
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        private class Enumerator : IEnumerator<T>
        {
            private LinkedListNode<T> _current;
            private LinkedList<T> _linkedList;

            public Enumerator(LinkedList<T> list)
            {
                _current = list.Head;
                _linkedList = list;
            }

            public T Current => _current.Data;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _current = null;
                _linkedList = null;
            }

            public bool MoveNext()
            {
                return (_current.Next != null);
            }

            public void Reset()
            {
                _current = _linkedList.Head;
            }
        }
    }
}
