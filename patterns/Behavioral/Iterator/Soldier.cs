namespace Iterator
{
    class Soldier
    {
        private const int MaxHealthSoldier = 100;

        public string Name { get; }
        public int CurrentHealth { get; protected set; }

        protected virtual int MaxHealthPoint => MaxHealthSoldier;

        public Soldier(string name)
        {
            Name = name;
            CurrentHealth = MaxHealthSoldier;
        }

        public void Treat()
        {
            CurrentHealth = MaxHealthPoint;
        }

        public void DamageReceived(int minuseHealthPoint)
        {
            CurrentHealth -= minuseHealthPoint;
        }

    }
}