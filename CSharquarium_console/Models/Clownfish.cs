using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public class Clownfish : FishEatingFish
    {
        #region Constructors

        public Clownfish() : base()
        {

        }

        public Clownfish(string name, Gender gender) : base(name, gender)
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
            return "This fish is a Clownfish. Clownfishes are awesome.\n";
        }
        #endregion
    }
}
