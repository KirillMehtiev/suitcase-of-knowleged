using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            A a1 = new A();
            A a2 = a1;

            Console.WriteLine(a1 == a2); // True

            a2 = a1.ShallowCopy();
            
            Console.WriteLine(a1 == a2); // False
        }
    }

    class A
    {
        public A ShallowCopy()
        {
            return MemberwiseClone() as A;
        }
    }

    static class AExtentions
    {
        public static A CopyFrom(this A a, A copyFrom)
        {
            return copyFrom.ShallowCopy();
        }
    }

    
}
