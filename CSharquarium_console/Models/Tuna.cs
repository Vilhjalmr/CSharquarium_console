using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public class Tuna : FishEatingFish
    {
        #region Constructors

        public Tuna() : base()
        {

        }
        public Tuna(string name, Gender gender) : base(name, gender)
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
            return String.Format("{0}\n{1} are delicious.\n", base.ToString(), GetType().Name);
        }
        #endregion
    }
}
