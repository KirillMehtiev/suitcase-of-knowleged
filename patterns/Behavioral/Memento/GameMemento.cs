namespace Memento
{
    class GameMemento
    {
        public GameMemento(GameState state)
        {
            GetState = state;
        }

        public GameState GetState { get; }
    }
}