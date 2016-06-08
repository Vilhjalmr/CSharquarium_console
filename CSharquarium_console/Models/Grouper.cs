using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharquarium_console.Models
{
    public class Grouper : FishEatingFish
    {
        #region Constructors

        public Grouper() : base()
        {

        }

        public Grouper(string name, Gender gender) : base(name, gender)
        {
            
        }
        #endregion

        #region Methods

        public override void Update(Aquarium Aq)
        {
            base.Update(Aq);
            // TODO: add eat() and other logic
        }

        public override string ToString()
        {
            return "This fish is a Grouper. Groupers are carnivorous.\n";
        }

        #endregion
    }
}
