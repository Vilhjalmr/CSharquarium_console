using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public class Sole : AlgaeEatingFish
    {
        #region Constructors

        public Sole() : base()
        {

        }

        public Sole(string name, Gender gender) : base(name, gender)
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
            return "This fish is a Sole. Soles are vegeterian.\n";
        }

        #endregion
    }
}
