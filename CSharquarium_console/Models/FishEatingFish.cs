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

        public void Eat(Fish DevouredFish, Aquarium Aq)
        {
            Console.WriteLine("{0} dévore brutalement {1}\n", this.Name, DevouredFish.Name );
            Aq.RemoveFish(DevouredFish);
        }

        public override void Update(Aquarium Aq)
        {
            Console.WriteLine("{0}Its name is {1}.\n{2} is updating.\n", this.ToString(), this.Name, this.Name);

            Random rnd = new Random();
            var f = Aq.Fishes[rnd.Next(0, Aq.Fishes.Count())];
            if (f == this)
            {
                Console.WriteLine("The {0} named {1} tried to eat itself but couldn't do that.", this.GetType(), this.Name);
            }
            else if (f.GetType() == this.GetType())
            {
                Console.WriteLine("The {0} named {1} tried to eat one of his own species, but couldn't do that.", this.GetType(), this.Name);
            }
            else
            {
                Console.WriteLine("The {0} named {1} eats the {2} named {3}", this.GetType(), this.Name, f.GetType(), f.Name);
                Eat(f, Aq);
            }
        }

        #endregion
    }
}
