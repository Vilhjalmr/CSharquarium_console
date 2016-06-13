using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharquarium_console.Models
{
    [Serializable]

    public class Aquarium
    {

        #region Properties

        public List<Organism> Organisms { get; private set; }
        public int turn = 0;

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

            List<Organism> AliveOrganisms = PseudoLink<Organism>.GetIf(Organisms, IsOrganismAlive);

            string str = string.Format("There are currently {0} fishes and {1} algae in the aquarium.\n: ",
                PseudoLink<Organism, Fish>.Count(Organisms),
                PseudoLink<Organism, Alga>.Count(Organisms));

            Console.WriteLine(str);
            WriteToFile(str);

            str = string.Format("{0} of these organisms are alive",
                AliveOrganisms.Count());

            Console.WriteLine(str);
            WriteToFile(str);            
        }
        public void StarveEveryFish()
        {
            Console.WriteLine("**********\nA fish needs a meal\n**********");
            // Each fish tries eating something
            foreach (Fish fish in PseudoLink<Organism, Fish>.GetSubset(Organisms))
            {
                if (fish.IsAlive)
                {
                    fish.LoseHP();
                    string str = string.Format("Fish of type {0} named {1}, {2}, {3} turns old is getting hungrier and loses 1 HP. They now have {4} HP.", fish.GetType().Name, fish.Name, fish.Gender, fish.Age, fish.HP);
                    WriteToFile(str);
                    if (IsFishHungry(fish))
                    {
                        str = string.Format("{0} is now hungry and will try to find something to eat.", fish.Name);
                        WriteToFile(str);
                    }
                }
            }

        }
        /// <summary>
        /// Each alga grows at each turn.
        /// Takes the form of gaining some HP.
        /// No upper bound as far as algae are concerned.
        /// </summary>
        public void GrowAlgae()
        {
            Console.WriteLine(" * *********\nAlgae growing!\n**********");
            foreach (Alga alga in PseudoLink<Organism, Alga>.GetSubset(Organisms))
            {
                if (alga.IsAlive)
                {
                    alga.RegainHP();
                    string str = string.Format("An alga just gained 1 HP and is now at {0} HP.", alga.HP);
                    WriteToFile(str);
                }
            }
        }
        /// <summary>
        /// Each organism of type fish gets one shot at eating.
        /// Tests are made to determine if random target can be eaten.
        /// Actions follow
        /// </summary>
        public void LunchTime()
        {
            Console.WriteLine("**********\nLunchTime Starts!\n**********");

            // Each fish tries to eat something
            foreach (Fish fish in PseudoLink<Organism, Fish>.GetSubset(Organisms))
            {
                // Get random element in Organisms. Send it to each fish. Conditions tested in Eat(Organism target)
                if (fish.IsAlive && fish.HP <= 5)
                {
                    Random rnd = new Random();
                    int r = rnd.Next(0, Organisms.Count());
                    Organism target = Organisms[r];
                    if (target.IsAlive)
                    {
                        fish.Eat(Organisms[r]);
                    }
                }
                     
            }
            Console.ResetColor();
            Console.WriteLine("**********\nLunchTime over! For now.\n**********");
        
        }
        /// <summary>
        /// Each turn, an organism get old. This is sad.
        /// </summary>
        public void GetOlder()
        {
            // If linq isn't an option, use if condition
            // Note: IsAlive condition is checked in both Fish and Alga's GrowOld implementation
            foreach (Organism org in Organisms.Where(w => w.IsAlive))
            {
                org.GrowOld();
                string str = null;
                if (org is Fish)
                {
                    Fish fish = org as Fish;
                    str = string.Format("The {0} named {1} is getting older. They're now {2} turns old.", fish.GetType().Name, fish.Name, fish.Age);
                }
                else if (org is Alga)
                {
                    str = string.Format("An alga just grew older. They're now {0} turns old.", org.Age);
                }
                WriteToFile(str);
            }
        }
        /// <summary>
        /// Used to manage fish reproduction.
        /// 
        /// </summary>
        public void ReproduceFishes()
        {
            List<Organism> FishList = new List<Organism>();
            FishList = PseudoLink<Organism, Fish>.GetSubset(Organisms);

            foreach (Fish fish in FishList) 
            {
                if (!IsFishHungry(fish))
                {
                    Random rnd = new Random();
                    int nbr = rnd.Next(0, FishList.Count);
                    Fish otherFish = ((Fish)FishList[nbr]);

                    if (otherFish != fish)  // A fish cannot inseminate themselves!
                    {
                        /* 
                         * Opportunistic hermaphrodism : 
                         * If fish is a sole or a clownfish and encounters same species and same sex,
                         * fish will switch sex, then engage in (newly found) monogamistic encounter.
                         */
                        if ((fish is Sole || fish is Clownfish) &&
                            otherFish.GetType().Name.Equals(fish.GetType().Name) &&
                            fish.Gender == otherFish.Gender
                            )
                        {
                            fish.SwitchSex();
                        }

                        // Monogamistic encounter
                        if (fish.GetType().Name.Equals(otherFish.GetType().Name) &&
                            fish.Gender != otherFish.Gender && otherFish.IsAlive)
                        {
                            // Add newborn fish to list
                            Organisms.Add(fish.GiveBirth(fish));

                            string str = string.Format("\tThe {0}s {1} and {2} had a child together!\n", fish.GetType().Name, fish.Name, otherFish.Name);

                            Aquarium.DualOutput(str);
                        }
                    }
                }
            }
        }
        public void ReproduceAlgae()
        {
            List<Organism> AlgaList = new List<Organism>();
            AlgaList = PseudoLink<Organism, Alga>.GetSubset(Organisms);

            foreach (Alga alga in AlgaList.Where(w => (w.HP >= 10) ))
            {
                Organisms.Add(alga.GiveBirth());
                alga.LoseHP(alga.HP / 2);
                string str = string.Format("An alga just gave birth to a smaller alga.");
            }
        }
        public void StatusDisplay()
        {
            List<Organism> ListFish = new List<Organism>();
            ListFish = PseudoLink<Organism, Fish>.GetSubset(Organisms);
            ListFish = PseudoLink<Organism>.GetIf(ListFish, IsOrganismAlive);

            string str = string.Format("At the end of turn {0}. {1} fishes alive. {2} algae alive. Still alive:",
                turn,
                PseudoLink<Organism>.GetCountWhen(ListFish, IsOrganismAlive),
                PseudoLink<Organism>.GetCountWhen((PseudoLink<Organism, Alga>.GetSubset(Organisms)), IsOrganismAlive));

            Console.WriteLine(str);
            WriteToFile(str);

            foreach (Fish fish in ListFish)
            {
                Console.WriteLine(" {0},", fish.Name);
            }
            ++turn;
        }
        

        public void Update()
        {
            Console.Clear();

            string str = string.Format("*** Turn {0} ***\n\n", turn);
            WriteToFile(str);

            InitialDisplay();
            StarveEveryFish();
            GrowAlgae();
            LunchTime();
            GetOlder();
            ReproduceFishes();
            ReproduceAlgae();

            StatusDisplay();
        }

        public static void WriteToFile(string str)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\temp\log.txt", true))
            {
                file.WriteLine(str);
            }
        }
        public static void DualOutput(string str)
        {
            Console.WriteLine(str);
            Aquarium.WriteToFile(str);
        }


        #endregion

        private static bool IsOrganismAlive(Organism org)
        {
            return org.IsAlive;
        }

        private static bool IsFishHungry(Fish fish)
        {
            return fish.HP < 5;
        }
    }
}
