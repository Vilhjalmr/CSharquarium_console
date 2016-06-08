using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public abstract class Organism
    {

        public int hp { get; private set; }
        public bool IsAlive { get; set; }

        public Organism()
        {
            this.hp = 10;
            this.IsAlive = true;
        }

        public void loseHP()
        {
            --this.hp;
        }
        public void loseHP (int v)
        {
            this.hp -= v;
            if (this.hp <= 0)
            {
                this.hp = 0;

            }
        }
        public void regainHP(int v)
        {
            this.hp += v;
        }

    }
}
