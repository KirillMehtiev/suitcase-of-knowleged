using System;
using System.Collections.Generic;
using System.Linq;

namespace Equality
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var car1 = new Car(CarColor.Blue, new DateTime(2017, 7, 17));
            var car2 = new Car(CarColor.Blue, new DateTime(2017, 7, 17));
            var car3 = (object)car2;

            if (car1.Equals(car2))
                Console.WriteLine("(car1.Equals(car2)) = True");
            if (car1 == car2)
                Console.WriteLine("(car1 == car2) = True");
            if (car3.Equals(car1))
                Console.WriteLine("(car3.Equals(car2)) = True");

            var cars = new List<Car>() { car1, car2 };
            var countWithoutDuplicates = cars.Distinct(new CarComparer()).Count();

            Console.WriteLine(countWithoutDuplicates);
        }
    }

}
