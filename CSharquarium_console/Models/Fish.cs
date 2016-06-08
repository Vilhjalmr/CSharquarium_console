using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public abstract class Fish : Organism
    {    
        #region Properties

        public string Name { get; set; }
        public Gender Gender { get; set; }
        #endregion

        #region Constructors
        public Fish() : base()
        {
            this.Name = "Loulou";
            this.Gender = Gender.Unknown;
        }
        public Fish(string name, Gender gender) : base()
        {
            this.Name = name;
            this.Gender = gender;
        }
        #endregion

        #region Methods
        public abstract void Update(Aquarium Aq);

        public override string ToString()
        {
            return String.Format("This is {0}. {0} is a {1}, and it has {2} HP", this.Name, GetType().Name, this.HP);
        }

        //public abstract void Eat();

        //public abstract void ChangeGender();

        #endregion
    }
}
