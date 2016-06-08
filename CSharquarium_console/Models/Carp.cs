using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public class Carp : AlgaeEatingFish
    {
        #region Constructors

        public Carp() : base()
        {

        }

        public Carp(string name, Gender gender) : base(name, gender)
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
            return "This fish is a Carp. Carps are a taciturn species.\n";
        }

        #endregion
    }
}
