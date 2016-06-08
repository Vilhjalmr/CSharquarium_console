using System;
using System.Collections.Generic;

namespace Tools{
	class Count<T,X>{
		public static int doCount(List<T> liste){
			
			int count = 0;
			foreach(T item in liste)
			{
				if(item is X)
				  count++;
			}

			return count;
		}
	}
}

namespace Tools{
	class Program{
		//public static void Main(string[] args){

  //          List<Personne> listePersonne = new List<Personne>{
  //              new Adult(),
  //              new Adult(),
  //              new Enfant(),
  //              new Enfant(),
  //              new Enfant()
  //          };
	
		//	Console.WriteLine(Count<Personne, Enfant>.doCount(listePersonne).ToString());
		//	Console.ReadKey();
		//}
	}

	class Personne {
		public string nom {get;set;}
		public string prenom {get;set;}
	}
	
	class Adult:Personne {
		
		public string Age {get;set;}
	}
	
	class Enfant : Personne
    {
		
		public string Age {get;set;}
	}
	
}