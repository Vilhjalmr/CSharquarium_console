using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public abstract class FishEatingFish : Fish
    {
        #region Properties
        CarnivorousFishRaces Race { get;  set; }
        #endregion


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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The {0} named {1} tries eating themselves but can't do that.", this.GetType().Name, this.Name);
            }
            else if (target.GetType().Name.Equals(this.GetType().Name)) // Fish tries to eat own species
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The {0} named {1} tries eating one of their own species but can't do that. Fucking cannibals!", this.GetType().Name, this.Name);
            }
            else if (target is Alga) // Fish tries to eat alga
            {
                Console.WriteLine("{0} is a {1}s and {1} don't eat no goddamn alga!", this.Name, this.GetType().Name);
            }
            else // Fish tries to eat another fish, of a different species
            {
                Fish targetedFish = (Fish)target;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The {0} named {1} brutally bites the {2} named {3}. Savage.", this.GetType().Name, this.Name, targetedFish.GetType().Name, targetedFish.Name);
                targetedFish.loseHP(4);
                this.regainHP(5);
                Console.WriteLine("The {0} named {1} now has {2}HP.", targetedFish.GetType().Name, targetedFish.Name, targetedFish.hp);
            }
        }

        

        public override void Update(Aquarium Aq)
        {
            Console.WriteLine("{0}Its name is {1} and {1} has {2} HP.\n{1} is updating.\n", this.ToString(), this.Name, this.hp);

            //TODO : à décommenter quand solution trouvée pour que f = sous-liste des poissons

            //if (f.Equals( this))
            //{
            //    Console.WriteLine("The {0} named {1} tried to eat itself but couldn't do that.", this.GetType(), this.Name);
            //}

            //else if (f.GetType() == this.GetType())
            //{
            //    Console.WriteLine("The {0} named {1} tried to eat one of his own species, but couldn't do that.", this.GetType(), this.Name);
            //}

            //else
            //{
            //    Console.WriteLine("The {0} named {1} eats the {2} named {3}", this.GetType(), this.Name, f.GetType(), f.Name);
            //    Eat(f, Aq);
            //}
        }

        #endregion
    }
}
