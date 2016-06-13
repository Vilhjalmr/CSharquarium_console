using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    [Serializable]
    public abstract class FishEatingFish : Fish
    {
        #region Constructors
        public FishEatingFish() : base()
        {
            
        }

        public FishEatingFish(string name, Gender gender) : 
            base (name, gender)
        {
            this.Name = name;
            this.Gender = gender;
        }

        #endregion


        #region Methods

        public override void Eat(Organism target)
        {
            if (target.Equals(this)) // Fish tries to eat themselves
            {
                string str = string.Format("The {0} named {1} tries to eat themselves but can't do that.", this.GetType().Name, this.Name);

                Console.ForegroundColor = ConsoleColor.Red;
                Aquarium.DualOutput(str);
            }
            else if (target.GetType().Name.Equals(this.GetType().Name)) // Fish tries to eat own species
            {
                string str = string.Format("The {0} named {1} tries to eat one of their own species but can't do that. Fucking cannibals!", this.GetType().Name, this.Name);

                Console.ForegroundColor = ConsoleColor.Red;
                Aquarium.DualOutput(str);
            }
            else if (!target.IsAlive)
            {
                Fish targetFish = target as Fish;
                string str = string.Format("The {0} named {1} encounters the dead body of {2}!", this.GetType().Name, this.Name, targetFish.Name);

                Console.ForegroundColor = ConsoleColor.Red;
                Aquarium.DualOutput(str);
            }
            else if (target is Alga) // Fish tries to eat alga
            {
                string str = string.Format("{0} is a {1} and {1}s don't eat no goddamn alga!", this.Name, this.GetType().Name);

                Aquarium.DualOutput(str);
            }
            else // Fish tries to eat another fish, of a different species
            {
                Fish targetedFish = target as Fish;

                string str = string.Format("The {0} named {1} brutally bites the {2} named {3}. Savage.", this.GetType().Name, this.Name, targetedFish.GetType().Name, targetedFish.Name);

                Console.ForegroundColor = ConsoleColor.Green;
                Aquarium.DualOutput(str);
                targetedFish.LoseHP(4);
                this.RegainHP(5);

                str = string.Format("The {0} named {1} now has {2}HP.", targetedFish.GetType().Name, targetedFish.Name, targetedFish.HP);

                Aquarium.DualOutput(str);
            }
        }

        #endregion
    }
}
