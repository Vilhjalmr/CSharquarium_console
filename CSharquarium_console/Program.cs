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
            string PathToSaveFile = string.Format("{0}\\..\\..", Directory.GetCurrentDirectory());
            PathToSaveFile = string.Format(@"{0}\CSharQuarium.xml", PathToSaveFile);

            if (File.Exists(PathToSaveFile))
            {
                // Check if savefile already exists. If so, load it, then run one update of the aquarium
                Aquarium JinYangAquarium = SaveLoadFile<Aquarium>.LoadFromXML(typeof(Aquarium), PathToSaveFile);
                JinYangAquarium.Update();
                Console.ReadLine();

                // Save file to XML using custom method
                SaveLoadFile<Aquarium>.SaveToXML(typeof(Aquarium), PathToSaveFile, JinYangAquarium);
            }

            // If not, start from scratch
            else GenerateNewSimulation(PathToSaveFile);
        }

        public static void GenerateNewSimulation(string path)
        {
            Aquarium JinYangAquarium = new Aquarium();
            JinYangAquarium.Initialize();

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