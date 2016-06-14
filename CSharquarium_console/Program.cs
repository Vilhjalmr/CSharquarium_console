using CSharquarium_console.Models;
using CSharquarium_console.Models.Instanciable;
using CSharquarium_console.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            string PathToSaveFile = @"C:\temp\aquariumtest.xml";

            if (File.Exists(PathToSaveFile))
            {
                // Check if savefile already exists. If so, load it, then run one update of the aquarium
                Aquarium JinYangAquarium = SaveLoadFile<Aquarium>.LoadFromXML(typeof(Aquarium), PathToSaveFile);
                JinYangAquarium.Update();
                Console.ReadLine();

                // Save file to XML using custom method
                SaveLoadFile<Aquarium>.SaveToXML(typeof(Aquarium), PathToSaveFile, JinYangAquarium);
            }

            // Si non, on génère une nouvelle simulation
            else GenerateNewSimulation(PathToSaveFile);
        }

        public static void GenerateNewSimulation(string path)
        {
            Aquarium JinYangAquarium = new Aquarium();
            JinYangAquarium.Initialize();

            // TODO: générer tous les poissons de départ de manière aléatoire
            // JinYangAquarium.Initialize(new int[] {4, 3, 2, 3, 2, 2, 4});

            //JinYangAquarium.AddFish(new Grouper());
            //JinYangAquarium.AddFish(new Grouper());
            //JinYangAquarium.AddFish(new Grouper());
            //JinYangAquarium.AddFish(new Grouper());

            //JinYangAquarium.AddFish(new Tuna());
            //JinYangAquarium.AddFish(new Tuna());
            //JinYangAquarium.AddFish(new Tuna());

            //JinYangAquarium.AddFish(new Clownfish());
            //JinYangAquarium.AddFish(new Clownfish());

            //JinYangAquarium.AddFish(new Sole());
            //JinYangAquarium.AddFish(new Sole());
            //JinYangAquarium.AddFish(new Sole());

            //JinYangAquarium.AddFish(new Bass());
            //JinYangAquarium.AddFish(new Bass());

            //JinYangAquarium.AddFish(new Carp());
            //JinYangAquarium.AddFish(new Carp());

            //JinYangAquarium.AddAlga(new Alga());
            //JinYangAquarium.AddAlga(new Alga());
            //JinYangAquarium.AddAlga(new Alga());
            //JinYangAquarium.AddAlga(new Alga());


            int count = 0;

            while (count < 1)
            {
                JinYangAquarium.Update();
                Console.ReadLine();
                ++count;
            }
            
            // Save file to XML using custom method
            SaveLoadFile<Aquarium>.SaveToXML(typeof(Aquarium), path, JinYangAquarium);

        }
    }
}