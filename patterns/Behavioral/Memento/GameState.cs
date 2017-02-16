namespace Memento
{
    class GameState
    {
        public GameState(int health, int monstersKilled)
        {
            GetHealth = health;
            GetMonstersKilled = monstersKilled;
        }

        public override string ToString()
        {
            return $"State: health = {GetHealth} and {GetMonstersKilled} monster(s) was killed!";
        }

        public int GetHealth { get; }

        public int GetMonstersKilled { get; }
    }
}