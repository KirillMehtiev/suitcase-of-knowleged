using System;

namespace Mediator
{
    abstract class BodyPart
    {
        private readonly Brain _brain;

        public BodyPart(Brain brain)
        {
            _brain = brain;
        }

        public void SomethingHappend()
        {
            _brain.SomethingHappenHandler(this);
        }
    }

    class Ear : BodyPart
    {
        private readonly Brain _brain;
        private string _sound;

        public Ear(Brain brain) : base(brain)
        {
            _brain = brain;
            _sound = string.Empty;
        }

        public void Heard(string sound)
        {
            Console.WriteLine("EAR HEARD: " + sound);
            _sound = sound;

            _brain.SomethingHappenHandler(this);
        }

        public string GetRecord()
        {
            return _sound;
        }
    }

    class Face : BodyPart
    {
        private readonly Brain _brain;
        private object _kissedBy;

        public Face(Brain brain) : base(brain)
        {
            _brain = brain;
            _kissedBy = null;
        }

        public void Smile()
        {
            Console.WriteLine("FACE is smiling! :)");
        }

        public void GetKiss(object kisedBy)
        {
            Console.WriteLine("FACE was kissed!");
            _kissedBy = kisedBy;

            _brain.SomethingHappenHandler(this);
        }

        public object GetKissInitiator()
        {
            return _kissedBy;
        }
    }

    class Leg : BodyPart
    {
        public Leg(Brain brain) : base(brain)
        {
        }

        public void MoveForward()
        {
            // TODO: Add move logic
        }

    }
}