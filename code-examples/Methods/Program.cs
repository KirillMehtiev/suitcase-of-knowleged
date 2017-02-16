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


            // *** Extention methods in use

            "Amazing".ShowItem();

            new[] {"Test", "Array"}.ShowItem();

            Action<object> a = (obj) => Console.WriteLine(obj.GetType());   // Throw NullReferenceExeption
            a.InvokeAndCatch<NullReferenceException>(null);                 // Swallows NullReferenceExeption

            Action b = "Kirik".ShowItem;
            b();

            // *** Partial Methods
            Base mBase = new Base();

            Console.WriteLine(mBase.Name);

            mBase.Name = "Kirill";

            Console.WriteLine(mBase.Name);

        }
    }

    class A
    {
        public A ShallowCopy()
        {
            return MemberwiseClone() as A;
        }
    }
}
