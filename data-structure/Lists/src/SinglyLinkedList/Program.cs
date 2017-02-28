using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<int>();
            
            list.Insert(0, 1);
            list.Add(5);
            
            list.Insert(1, int.MaxValue);

            Console.WriteLine(list[0]);
            System.Collections.Generic.LinkedList<int> _list = new System.Collections.Generic.LinkedList<int>();
        }
    }
}
