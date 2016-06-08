using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public abstract class AlgaeEatingFish : Fish
    {
        #region Constructors
        public AlgaeEatingFish() : base()
        { }

        public AlgaeEatingFish(string name, Gender gender) :
            base(name, gender)
        {
            this.Name = name;
            this.Gender = gender;
        }

        #endregion

        #region Methods

        public override void Eat(Organism target)
        {
            if (target is Fish)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The {0} named {1} meets another fish but they want algae!", this.GetType().Name, this.Name);
            }
            else if (target is Alga)
            {
                Console.WriteLine("The {0} named {1} eats some alga.", this.GetType().Name, this.Name);
            }
        }

        public override void Update(Aquarium Aq)
        {
            //Console.WriteLine("{0}Its name is {1} and {1} has {2} HP.\n{1} is updating.\n", this.ToString(), this.Name, this.HP);
        }

        
        #endregion

    }
}
