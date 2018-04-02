using System;
using System.Collections.Generic;
using System.IO;

namespace StatPlayer
{
    class Program
    {
        static League league;
        
        static void Main(string[] args)
        {
            init();

            foreach (Joueur j in league.ProduirClassementJoueurParEquipe())
            {
                Console.WriteLine(j);
            }
            Console.WriteLine("************************Classement general Joueur*************************");
            foreach (JoueurDeSurface j in league.ProduirClassementGenJoueurDeSurface())
            {
                Console.WriteLine(j);
            }
            Console.WriteLine("************************Classement general Gardien*************************");
            foreach (Gardien j in league.ProduirClassementGenGardien())
            {
                Console.WriteLine(j);
            }

        }
        private static void init()
        {
            league = new League(35);
            league.AffectationJoueurDansEquipe();
        }
    }
}
