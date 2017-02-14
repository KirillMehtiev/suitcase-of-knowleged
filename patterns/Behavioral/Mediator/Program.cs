using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var brain = new Brain();
            var byLovelyPerson = "Lovely!";

            brain.Ear.Heard("You are really cool! And I want to kiss you!");
            brain.Face.GetKiss(byLovelyPerson);
        }
    }
}
