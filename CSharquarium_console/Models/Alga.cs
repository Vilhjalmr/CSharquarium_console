using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    [Serializable]
    public class Alga : Organism
    {

        public Alga() : base()
        {
            
        }

        public Alga(int hp, int age = 0) : base(age)
        {
            this.HP = hp;
        }

        public override void GrowOld()
        {
            if (this.IsAlive)
            {
                ++this.Age;
                if (this.Age >= 20)
                {
                    this.Die();
                }
            }
        }

        public Alga GiveBirth()
        {
            return new Alga(this.HP / 2);
        }
    }
}
