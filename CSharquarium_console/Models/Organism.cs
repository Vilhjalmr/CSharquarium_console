using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public abstract class Organism
    {

        public int HP { get; set; }

        public Organism()
        {
            this.HP = 10;
        }


    }
}
