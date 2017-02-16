using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            var caretaker = new Caretaker();

            caretaker.F5();
            caretaker.Shoot();
            caretaker.F5();
            caretaker.Shoot();
            caretaker.Shoot();
            caretaker.Shoot();
            caretaker.F9();
            caretaker.Shoot();

            Console.ReadKey();
        }
    }
}
