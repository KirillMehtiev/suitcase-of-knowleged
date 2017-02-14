namespace Iterator
{
    class Hero : Soldier
    {
        private const int MaxHealthHero = 500;

        protected override int MaxHealthPoint => MaxHealthHero;

        public Hero(string name) : base(name)
        {
            CurrentHealth = MaxHealthHero;
        }
    }
}