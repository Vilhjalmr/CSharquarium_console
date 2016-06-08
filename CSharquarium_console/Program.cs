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
            Aquarium YinYangAquarium = new Aquarium();

            YinYangAquarium.AddFish(new Grouper("Matthew", Gender.Male));
            YinYangAquarium.AddFish(new Grouper("Mark", Gender.Male));
            YinYangAquarium.AddFish(new Grouper("Luke", Gender.Male));
            YinYangAquarium.AddFish(new Grouper("John", Gender.Male));
            
            YinYangAquarium.AddFish(new Tuna("Dean", Gender.Male));
            YinYangAquarium.AddFish(new Tuna("Sam", Gender.Male));
            YinYangAquarium.AddFish(new Tuna("Chaos", Gender.Female));
            
            YinYangAquarium.AddFish(new Clownfish("Lara", Gender.Female));
            YinYangAquarium.AddFish(new Clownfish("Indiana", Gender.Male));
            
            YinYangAquarium.AddFish(new Sole("Gandhi", Gender.Male));
            YinYangAquarium.AddFish(new Sole("Natalie", Gender.Female));
            
            YinYangAquarium.AddFish(new Bass("Charles", Gender.Male));
            YinYangAquarium.AddFish(new Bass("Forest", Gender.Male));
            
            YinYangAquarium.AddFish(new Carp("Gustav", Gender.Male));
            YinYangAquarium.AddFish(new Carp("Shania", Gender.Female));
            
            YinYangAquarium.AddAlga(new Alga());
            YinYangAquarium.AddAlga(new Alga());
            YinYangAquarium.AddAlga(new Alga());
            YinYangAquarium.AddAlga(new Alga());

            int count = 0;

            while (count<20)
            {
                YinYangAquarium.Update();
                Console.ReadLine();
                ++count;
            }

            

        }
    }
}
