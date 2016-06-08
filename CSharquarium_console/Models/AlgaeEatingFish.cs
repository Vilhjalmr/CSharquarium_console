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

        public void Eat(Alga alga, Aquarium Aq)
        {
            //Console.WriteLine("{0} broute paisiblement une algue...\n", this.Name);
            //Aq.RemoveAlga(alga);
        }

        public override void Update(Aquarium Aq)
        {
            //Console.WriteLine("{0}Its name is {1} and {1} has {2} HP.\n{1} is updating.\n", this.ToString(), this.Name, this.HP);
        }

        
        #endregion

    }
}
