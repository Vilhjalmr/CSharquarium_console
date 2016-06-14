using CSharquarium_console.Models.Instanciable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharquarium_console.Models
{
    [Serializable]
    [XmlInclude(typeof(Alga))]
    [XmlInclude(typeof(Fish))]
    [XmlInclude(typeof(AlgaeEatingFish))]
    [XmlInclude(typeof(FishEatingFish))]
    [XmlInclude(typeof(Grouper))]
    [XmlInclude(typeof(Sole))]
    [XmlInclude(typeof(Tuna))]
    [XmlInclude(typeof(Carp))]
    [XmlInclude(typeof(Bass))]
    [XmlInclude(typeof(Clownfish))]

    public abstract class Organism
    {
        public int HP { get; /*protected*/ set; }
        public int Age { get; /*protected*/ set; }
        public bool IsAlive { get; /*protected*/ set; }

        public Organism()
        {
            //Random rnd = new Random();

            this.HP = 10;
            this.IsAlive = true;
            this.Age = 1/*rnd.Next(0, 19)*/;
        }
        public Organism(int age = 0)
        {
            this.HP = 10;
            this.IsAlive = true;
            this.Age = age;
        }


        public abstract void GrowOld();
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
        /// <summary>
        /// All organism must die. This method can be called from LoseHP or from GrowOld
        /// </summary>
        public void Die()
        {
            this.IsAlive = false;

            string str = string.Format("An organism of type {0} died.", this.GetType().Name);

            Aquarium.DualOutput(str);
        }

    }
}
