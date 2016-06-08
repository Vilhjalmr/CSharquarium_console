using CSharquarium_console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Aquarium ShenshinAquarium = new Aquarium();

            ShenshinAquarium.AddFish(new Grouper("Matthew", Gender.Male));
            ShenshinAquarium.AddFish(new Grouper("Mark", Gender.Male));
            ShenshinAquarium.AddFish(new Grouper("Luke", Gender.Male));
            ShenshinAquarium.AddFish(new Grouper("John", Gender.Male));

            ShenshinAquarium.AddFish(new Tuna("Dean", Gender.Male));
            ShenshinAquarium.AddFish(new Tuna("Sam", Gender.Male));
            ShenshinAquarium.AddFish(new Tuna("Chaos", Gender.Female));

            ShenshinAquarium.AddFish(new Clownfish("Lara", Gender.Female));
            ShenshinAquarium.AddFish(new Clownfish("Indiana", Gender.Male));

            ShenshinAquarium.AddFish(new Sole("Gandhi", Gender.Male));
            ShenshinAquarium.AddFish(new Sole("Natalie", Gender.Female));

            ShenshinAquarium.AddFish(new Bass("Charles", Gender.Male));
            ShenshinAquarium.AddFish(new Bass("Forest", Gender.Male));

            ShenshinAquarium.AddFish(new Carp("Gustav", Gender.Male));
            ShenshinAquarium.AddFish(new Carp("Shania", Gender.Female));

            ShenshinAquarium.AddAlga(new Alga());
            ShenshinAquarium.AddAlga(new Alga());
            ShenshinAquarium.AddAlga(new Alga());
            ShenshinAquarium.AddAlga(new Alga());

            int count = 0;

            while (count<20)
            {
                ShenshinAquarium.Update();
                Console.ReadLine();
                ++count;
            }

            

        }
    }
}
