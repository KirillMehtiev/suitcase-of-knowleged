using System.Collections.Generic;

namespace Memento
{
    class Caretaker
    {
        private readonly GameOriginator _game = new GameOriginator();
        private readonly Stack<GameMemento> _quickSaves = new Stack<GameMemento>();

        public void Shoot()
        {
            _game.Play();
        }

        public void F5()
        {
            _quickSaves.Push(_game.SaveGame());
        }

        public void F9()
        {
            _game.LoadGame(_quickSaves.Peek());
        }
    }
}