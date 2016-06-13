using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    [Serializable]
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
                string str = string.Format("The {0} named {1} meets another fish but they want algae!", this.GetType().Name, this.Name);

                Console.ForegroundColor = ConsoleColor.Red;
                Aquarium.DualOutput(str);
            }
            else if (target is Alga)
            {
                string str = string.Format("The {0} named {1} eats some alga.", this.GetType().Name, this.Name);

                Aquarium.DualOutput(str);

                target.LoseHP(2);
                this.RegainHP(3);
            }
        }
        
        #endregion

    }
}
