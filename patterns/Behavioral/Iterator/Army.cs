using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Iterator
{
    class Army : IEnumerable<Soldier>
    {
        public List<ArmyGroup> Groups { get; private set; }
        public Hero Hero { get; private set; }

        public Army(Hero hero)
        {
            Hero = hero;
            Groups = new List<ArmyGroup>();
        }

        public void AddGroup(ArmyGroup armyGroup)
        {
            Groups.Add(armyGroup);
        }

        public IEnumerator<Soldier> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Enumerator : IEnumerator<Soldier>
        {
            private int _solderIndex;
            private List<Soldier> _soldiers;

            public Enumerator(Army army)
            {
                _solderIndex = -1;

                _soldiers = new List<Soldier> { army.Hero };
                _soldiers.AddRange(army.Groups.SelectMany(s => s.Soldiers));
            }

            public bool MoveNext()
            {
                _solderIndex++;

                return (_solderIndex < _soldiers.Count);
            }

            public void Reset()
            {
                _solderIndex = -1;
            }

            public Soldier Current {
                get
                {
                    try
                    {
                        return _soldiers[_solderIndex];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _soldiers = null;
            }
        }
    }

    class ArmyGroup
    {
        public List<Soldier> Soldiers { get; private set; }

        public ArmyGroup()
        {
            Soldiers = new List<Soldier>();
        }

        public void AddSoldier(Soldier soldier)
        {
            Soldiers.Add(soldier);
        }
    }
}