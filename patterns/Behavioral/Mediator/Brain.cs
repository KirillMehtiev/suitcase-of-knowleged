using System;

namespace Mediator
{
    class Brain
    {
        // Mediator
        public Brain()
        {
            CreateBodyParts();
        }

        private void CreateBodyParts()
        {
            Ear = new Ear(this);
            Face = new Face(this);
            Leg = new Leg(this);
        }

        public Ear Ear { get; private set; }
        public Face Face { get; private set; }
        public Leg Leg { get; private set; }

        public void SomethingHappenHandler(BodyPart bodyPart)
        {
            if (bodyPart is Ear)
            {
                var sound = Ear.GetRecord();

                if(sound.Contains("you") && sound.Contains("cool"))
                    Face.Smile();
            }
            else if (bodyPart is Face)
            {
                var kissInitiator = Face.GetKissInitiator();

                if (Object.ReferenceEquals(kissInitiator, null))
                {
                    // kiss initiator is definitely zombie!
                    Leg.MoveForward();
                }
                else
                {
                    Console.WriteLine("Nice! :)");
                }
                
            } 
            else if (bodyPart is Leg) { }
        }
    }
}