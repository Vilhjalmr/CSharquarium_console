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


            Console.WriteLine("There are currently {0} fishes and {1} algae in the aquarium.\nThe fishes are: ",
                PseudoLink<Organism, Fish>.Count(Organisms),
                PseudoLink<Organism, Alga>.Count(Organisms));
            Console.WriteLine("{0} of these organisms are alive",
                AliveOrganisms.Count());

            //foreach (var item in PseudoLink<Organism, Fish>.GetSubset(Organisms))
            //{
            //    Console.WriteLine(item.ToString());
            //}
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
            Console.WriteLine("**********\nAlgae growing!\n**********");
            foreach (Alga alga in PseudoLink<Organism, Alga>.GetSubset(Organisms))
            {
                if (alga.IsAlive)
                {
                    alga.RegainHP();
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
            foreach (Organism org in Organisms.Where(w => w.IsAlive))
            {
                org.GrowOld();                
            }
        }
        

        public void Update()
        {
            InitialDisplay();
            StarveEveryFish();
            GrowAlgae();
            LunchTime();
            GetOlder();

            List<Organism> ListFish = new List<Organism>();
            ListFish = PseudoLink<Organism, Fish>.GetSubset(Organisms);
            ListFish = PseudoLink<Organism>.GetIf(ListFish, IsOrganismAlive);

            Console.WriteLine("At the end of turn {0}. {1} fishes alive. {2} algae alive. Still alive:", 
                turn, 
                PseudoLink<Organism>.GetCountWhen(ListFish, IsOrganismAlive),
                PseudoLink<Organism>.GetCountWhen( ( PseudoLink<Organism, Alga>.GetSubset(Organisms) ), IsOrganismAlive));
            foreach (Fish fish in ListFish)
            {
                Console.WriteLine(" {0},", fish.Name);
            }
            ++turn;
        }



        #endregion

        private static bool IsOrganismAlive(Organism org)
        {
            return org.IsAlive;
        }
    }
}
