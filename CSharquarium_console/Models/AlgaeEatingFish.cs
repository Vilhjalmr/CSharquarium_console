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

        /// <summary>
        /// A herbivorous fish tests if target is alga or fish. If alga, said fish eats it.
        /// </summary>
        /// <param name="target"></param>
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
                target.LoseHP(2);
                this.RegainHP(3);
            }
        }

        // TODO: decide if this needs to be removed
        public override void Update(Aquarium Aq)
        {
            //Console.WriteLine("{0}Its name is {1} and {1} has {2} HP.\n{1} is updating.\n", this.ToString(), this.Name, this.HP);
        }

        
        #endregion

    }
}
