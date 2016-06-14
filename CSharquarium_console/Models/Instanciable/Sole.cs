using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models.Instanciable
{
    [Serializable]
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

        public override string ToString()
        {
            return String.Format("{0}\n{1} are vegetarian. And gay.\n", base.ToString(), GetType().Name);

        }



        #endregion
    }
}
