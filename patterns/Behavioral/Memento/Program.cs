using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

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

    class GameOriginator
    {
        private GameState _gameState = new GameState(100, 0);

        public void Play()
        {
            Console.WriteLine(_gameState.ToString());

            _gameState = new GameState((int)(_gameState.GetHealth * 0.8), _gameState.GetMonstersKilled * 7);
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

    class GameMemento
    {
        public GameMemento(GameState state)
        {
            GetState = state;
        }

        public GameState GetState { get; }
    }

    class Caretaker
    {
         //TODO: write code here ;)
    }
}
