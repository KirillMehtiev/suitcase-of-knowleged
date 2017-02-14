using System;
using System.Collections.Generic;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var hero = new Hero("Denis");
            var army = new Army(hero);

            var groupA = new ArmyGroup();
            for (int i = 0; i < 4; i++) groupA.AddSoldier(new Soldier($"Alpha: " + i));

            var groupB = new ArmyGroup();
            for (int i = 0; i < 4; i++) groupB.AddSoldier(new Soldier($"Beta: " + i));

            army.AddGroup(groupA);
            army.AddGroup(groupB);

            foreach (var soldier in army)
            {
                soldier.DamageReceived(77);
                Console.WriteLine($"{soldier.Name} {soldier.CurrentHealth}");
            }

            var armyIterator = (army as IEnumerable<Soldier>).GetEnumerator();

            while (armyIterator.MoveNext())
            {
                var soldier = armyIterator.Current;
                soldier.Treat();
                Console.WriteLine($"{soldier.Name} {soldier.CurrentHealth}");
            }
            
            Console.ReadKey();
        }
    }
}
