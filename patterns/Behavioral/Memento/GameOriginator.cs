using System;

namespace Memento
{
    class GameOriginator
    {
        private GameState _gameState = new GameState(100, 0);

        public void Play()
        {
            Console.WriteLine(_gameState.ToString());

            _gameState = new GameState((int)(_gameState.GetHealth * 0.8), _gameState.GetMonstersKilled + 7);
        }

        public GameMemento SaveGame()
        {
            return new GameMemento(_gameState);
        }

        public void LoadGame(GameMemento gameMemento)
        {
            _gameState = gameMemento.GetState;
        }
    }
}