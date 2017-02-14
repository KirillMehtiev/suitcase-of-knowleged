using System;
using System.Collections;
using System.Collections.Generic;
using Xunit.Sdk;

namespace SinglyLinkedList
{
    class LinkedList<T> : IEnumerable<T>
    {
        private int _count;
        private LinkedListNode<T> _firstNode;
        private LinkedListNode<T> _lastNode;

        public int Count
        {
            get { return _count; }
        }

        public LinkedListNode<T> Head => _firstNode;

        public T First
        {
            get { return _firstNode == null ? default(T) : _firstNode.Data; }
        }

        public T Last
        {
            //TODO: Added some logic to update last after insert and delete operation
            get { return _lastNode == null ? default(T) : _lastNode.Data; }
        }

        public bool IsEmpty => _count == 0;

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
                _firstNode = item;
                _lastNode = item;
            }
            else if (_count > 0)
            {
                _firstNode = item;
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
                _firstNode = item;
                _lastNode = item;
            }
            else if (_count > 0)
            {
                _lastNode.Next = item;
                _lastNode = item;
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
        /// <param name="index">Zero base index for data value to be inserted to the list.</param>
        public void InsertAt(T data, int index)
        {
            if (data == null) throw new ArgumentNullException();
            if (index < 0 && index < _count) throw new ArgumentOutOfRangeException("Index out of range!");

            var itemToBeInserted = new LinkedListNode<T>(data);

            //TODO: Split for three part prepend, append (use corresponding method) and insert in the range

            if (IsEmpty)
            {
                _firstNode = itemToBeInserted;
                _lastNode = itemToBeInserted;
            }
            else if (_count > 0)
            {
                if (index == 0)
                {
                    itemToBeInserted.Next = _firstNode;
                    _firstNode = itemToBeInserted;
                }
                else
                {
                    var counter = 0;
                    var current = _firstNode;

                    while (counter < index)
                    {
                        if ((counter + 1) == index)
                        {
                            var next = current.Next;
                            current.Next = itemToBeInserted;
                            itemToBeInserted.Next = next;
                        }
                        counter++;
                    }

                    // insert at the end - update Last
                    if (_count - 1 == index)
                    {
                        _lastNode = itemToBeInserted;
                    }
                }

            }
            else
            {
                throw new Exception($"Can not insert item. Count = {_count} IndexToInsert = {index}");
            }

            IncreaseCount(1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (IsEmpty) throw new Exception("The list is empty!");
            if (index < 0 && index < _count) throw new ArgumentOutOfRangeException("Index out of range!");

            var counter = 0;
            var current = _firstNode;

            while (counter < index)
            {
                if ((counter + 1) == index)
                {
                    var itemToBeDeleted = current.Next;
                    current.Next = itemToBeDeleted.Next;
                    itemToBeDeleted.Dispose();
                    DecreaseCount(1);
                }
                counter++;
            }
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
