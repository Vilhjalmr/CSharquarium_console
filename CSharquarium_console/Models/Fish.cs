using System;
using System.Collections.Generic;
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

        // TODO: implement this
        //public abstract Fish GiveBirth(Fish mate);

        // TODO: implement this
        private string GenerateName()
        {
            
            return "loulou";
        }
        // TODO : implement this
        private Gender GenerateGender()
        {
            return Gender.Male;
        }
        public override void GrowOld()
        {
            if (this.IsAlive)
            {
                ++this.Age;
                // Some types of fish change sex with age
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
