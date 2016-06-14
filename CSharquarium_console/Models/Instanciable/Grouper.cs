using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharquarium_console.Models.Instanciable
{
    [Serializable]
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
        public override string ToString()
        {
            return String.Format("{0}\n{1} are carnivorous\n", base.ToString(), GetType().Name);

        }

        


        #endregion
    }
}
