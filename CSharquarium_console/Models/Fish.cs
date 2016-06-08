using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public abstract class Fish
    {    
        #region Properties
        public string Name { get; set; }
        public Gender Gender { get; set; }
        #endregion

        #region Constructors
        public Fish()
        {
            this.Name = "Loulou";
            this.Gender = Gender.Unknown;
        }
        public Fish(string name, Gender gender)
        {
            this.Name = name;
            this.Gender = gender;
        }
        #endregion

        #region Methods
        public abstract void Update(Aquarium Aq);

        //public abstract void Eat();

        //public abstract void ChangeGender();

        #endregion
    }
}
