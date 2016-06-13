using CSharquarium_console.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSharquarium_console
{
    // TODO: ajouter événements / multithreading

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
            YinYangAquarium.AddFish(new Clownfish("Indiana", Gender.Female));
            
            YinYangAquarium.AddFish(new Sole("Gandhi", Gender.Male));
            YinYangAquarium.AddFish(new Sole("Natalie", Gender.Female));
            YinYangAquarium.AddFish(new Sole("Batgirl", Gender.Female));

            YinYangAquarium.AddFish(new Bass("Charles", Gender.Male));
            YinYangAquarium.AddFish(new Bass("Forest", Gender.Male));
            
            YinYangAquarium.AddFish(new Carp("Gustav", Gender.Male));
            YinYangAquarium.AddFish(new Carp("Shania", Gender.Female));
            
            YinYangAquarium.AddAlga(new Alga());
            YinYangAquarium.AddAlga(new Alga());
            YinYangAquarium.AddAlga(new Alga());
            YinYangAquarium.AddAlga(new Alga());

            int count = 0;

            while (count<5)
            {
                YinYangAquarium.Update();
                Console.ReadLine();
                ++count;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Aquarium));

            //var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            //System.IO.FileStream file = System.IO.File.Create(path);

            //serializer.Serialize(file, YinYangAquarium);
            //file.Close();

            // SERIALIZE
            using (StreamWriter writer = new StreamWriter(@"C:\temp\aquariumtest.xml"))
            {
                serializer.Serialize(writer, YinYangAquarium);

            }
        }
    }
}