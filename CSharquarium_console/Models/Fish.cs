using CSharquarium_console.Models.Instanciable;
using CSharquarium_console.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    [Serializable]
    public abstract class Fish : Organism
    {    
        #region Properties

        public string Name { get; set; }
        public Gender Gender { get; set; }

        #endregion

        #region Constructors
        public Fish() : base()
        {
            this.Name = GenerateName();
            this.Gender = GenerateGender();
        }
        public Fish(string name, Gender gender) : base()
        {
            this.Name = name;
            this.Gender = gender;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return String.Format("This is {0}. {0} is a {1}, and it has {2} HP", this.Name, GetType().Name, this.HP);
        }

        private string GenerateName()
        {
            int nbr = CustomRandom.GetRandom(200);

            string path = string.Format("{0}\\..\\..", Directory.GetCurrentDirectory());
            path = string.Format(@"{0}\Names.txt", path);

            return File.ReadLines(path).Skip(nbr).Take(1).First().Trim();

        }
        private Gender GenerateGender()
        {
            Random rnd = new Random();
            if (rnd.Next(0, 42) % 2 == 0)
                return Gender.Male;
            else
                return Gender.Female;
        }
        public override void GrowOld()
        {
            if (this.IsAlive)
            {
                ++this.Age;
                // Some types of fish change sex with age. 
                // TODO: Could be done more elegantly (enum sexuality?)
                if (this.Age == 10 && (this is Grouper || this is Bass))
                {
                    Fish fish = this as Fish;
                    fish.SwitchSex();
                }
            }
            
        }
        public void SwitchSex()
        {
            if (this.Gender == Gender.Male)
            {
                this.Gender = Gender.Female;
            }
            else
            {
                this.Gender = Gender.Male;
            }
            Console.WriteLine("\t\t{0} named {1} just became {2}", this.GetType().Name, this.Name, this.Gender);
        }
        public Fish GiveBirth(Fish fish)
        {
            return GetType().GetConstructor(Type.EmptyTypes).Invoke(new Object[] { }) as Fish;
        }
        public abstract void Eat(Organism target);

        //public abstract void ChangeGender();

        #endregion
    }
}
