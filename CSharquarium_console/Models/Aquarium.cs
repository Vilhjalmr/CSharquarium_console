using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public class Aquarium
    {
        #region Properties
        public List<Fish> Fishes { get; private set; }
        public List<Alga> Algae { get; private set; }
        #endregion

        #region Constructors
        public Aquarium()
        {
            Fishes = new List<Fish>();
            Algae = new List<Alga>();
        }
        #endregion

        #region Methods
        public void AddFish(Fish fish)
        {
            Fishes.Add(fish);
        }

        public void RemoveFish(Fish fish)
        {
            Fishes.Remove(fish);
        }

        public void AddAlga(Alga alga)
        {
            Algae.Add(alga);
        }

        public void RemoveAlga(Alga alga)
        {
            Algae.Remove(alga);
        }

        public void Update()
        {
            Console.WriteLine("There are currently {0} fishes and {1} algae in the aquarium.\nThe fishes are: ",
                Fishes.Count, Algae.Count);
            for (int i=0; i<Fishes.Count; ++i)
            {
                Console.WriteLine("- {0}, {1}.", Fishes[i].Name, Fishes[i].Gender);
            }

            Console.WriteLine("******************\nDébut des updates\n******************");

            for (int i=0; i<Fishes.Count(); ++i)
            {
                Fishes[i].Update(this);
                Console.WriteLine("*** Next Fish ***\n");
            }
        }
        #endregion
    }
}
