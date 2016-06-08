﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    public class Aquarium
    {
        #region Properties

        public List<Organism> Organisms { get; private set; }

        //public List<Fish> Fishes { get; private set; }
        //public List<Alga> Algae { get; private set; }
        #endregion

        #region Constructors
        public Aquarium()
        {
            Organisms = new List<Organism>();
            //Fishes = new List<Fish>();
            //Algae = new List<Alga>();
        }
        #endregion

        #region Methods
        public void AddFish(Fish fish)
        {
            Organisms.Add(fish);
        }

        public void RemoveFish(Fish fish)
        {
            Organisms.Remove(fish);
        }

        public void AddAlga(Alga alga)
        {
            Organisms.Add(alga);
        }

        public void RemoveAlga(Alga alga)
        {
            Organisms.Remove(alga);
        }

        public void Initialize()
        {
            // TODO: Initialize aquarium with random fishes and algae
        }

        public void InitialDisplay()
        {
            int FishesCount, AlgaeCount;
            // using Linq
            //FishesCount = Organisms.Count(organism => organism is Fish);
            //AlgaeCount = Organisms.Count(organism => organism is Alga);

            // using custom method
            FishesCount = PseudoLink<Organism, Fish>.Count(Organisms);
            AlgaeCount = PseudoLink<Organism, Alga>.Count(Organisms);

            Console.WriteLine("There are currently {0} fishes and {1} algae in the aquarium.\nThe fishes are: ",
                PseudoLink<Organism, Fish>.Count(Organisms),
                PseudoLink<Organism, Alga>.Count(Organisms));

            foreach (var item in PseudoLink<Organism, Fish>.GetSubset(Organisms))
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void StarveEveryFish()
        {
            Console.WriteLine("**********\nA fish needs a meal\n**********");
            // Each fish tries eating something
            foreach (Fish fish in PseudoLink<Organism, Fish>.GetSubset(Organisms))
            {
                --fish.HP;
            }

        }

        public void LunchTime()
        {
            Console.WriteLine("**********\nLunchTime Starts!\n**********");
            // Each fish tries eating something
            foreach (Fish fish in PseudoLink<Organism, Fish>.GetSubset(Organisms))
            {
                // Get random element in Organisms. Test. Proceed. Fuck bitches.
                Random rnd = new Random();
                int r = rnd.Next(0, Organisms.Count());
                Organism target = Organisms[r];


                // Case1: fish is carnivorous
                if (fish is FishEatingFish)
                {
                    if (target.Equals(fish))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The {0} named {1} tries eating themselves but can't do that.", fish.GetType().Name, fish.Name);
                    }
                    else if (target.GetType().Name.Equals(fish.GetType().Name))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The {0} named {1} tries eating one of their own species but can't do that. Fucking cannibals!", fish.GetType().Name, fish.Name);
                    }
                    else if (target is Alga)
                    {
                        Console.WriteLine("{0} is a {1} and they don't eat no goddamn alga!", fish.Name, fish.GetType().Name);
                    }
                    else
                    {
                        Fish targetedFish = (Fish)target;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("The {0} named {1} brutally devours the {2} named {3}. Savage.", fish.GetType().Name, fish.Name, targetedFish.GetType().Name, targetedFish.Name);
                    }
                }
                else if (fish is AlgaeEatingFish)
                {
                    if (target is Fish)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The {0} named {1} meets another fish but they want algae!", fish.GetType().Name, fish.Name);
                    }
                    else
                    {
                        Console.WriteLine("The {0} named {1} eats some alga.", fish.GetType().Name, fish.Name);
                    }
                }
            }
            Console.ResetColor();
            Console.WriteLine("**********\nLunchTime over! For now.\n**********");
        
        }

        public void Update()
        {

            InitialDisplay();
            StarveEveryFish();
            LunchTime();

            
        }



        #endregion
    }
}