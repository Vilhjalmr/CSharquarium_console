using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public abstract class Organism
    {

        public int HP { get; private set; }
        public int Age { get; private set; }
        public bool IsAlive { get; set; }

        public Organism()
        {
            Random rnd = new Random();

            this.HP = 10;
            this.IsAlive = true;
            this.Age = 1/*rnd.Next(0, 19)*/;
        }


        public void GrowOld()
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
        public void LoseHP()
        {
            if (this.IsAlive)
                --this.HP;
        }
        public void LoseHP (int v)
        {
            if (this.IsAlive)
            {
                this.HP -= v;
                if (this.HP <= 0)
                {
                    this.Die();
                }
            }
            
        }
        public void RegainHP()
        {
            ++this.HP;
        }
        public void RegainHP(int v)
        {
            this.HP += v;
        }
        public abstract void GiveBirth();
        /// <summary>
        /// All organism must die. This method can be called from LoseHP or from GrowOld
        /// </summary>
        public void Die()
        {
            this.IsAlive = false;
            Console.WriteLine("An organism of type {0} died.", this.GetType().Name);
        }

    }
}
