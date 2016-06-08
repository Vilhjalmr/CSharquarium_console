using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public class Bass : AlgaeEatingFish
    {
        #region Constructors

        public Bass() : base()
        {

        }

        public Bass(string name, Gender gender) : base(name, gender)
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
            return String.Format("{0}\nBasses are essential in the well being of music.\n", base.ToString());
        }

        #endregion
    }
}
