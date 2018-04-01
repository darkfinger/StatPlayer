using System;

namespace StatPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Joueur a = new JoueurDeSurface("dav k", "c", 5, 4, 6);
            Console.WriteLine(a);
            Console.WriteLine("-------------------------------------------------");
            Joueur b = new JoueurDeSurface("dav kapanga kap", "AG", 0, 4, 6);
            Console.WriteLine(b);
            Console.WriteLine("-------------------------------------------------");
            Joueur c = new Gardien("dav kan kan", "G", 5, 0, 0,0,0,0,0);
            Console.WriteLine(c);
            Console.WriteLine("-------------------------------------------------");
            Joueur d = new JoueurDeSurface("dav kaz", "ad", 0, 4, 6);
            Console.WriteLine(d);
            Console.WriteLine("-------------------------------------------------");


            Joueur test = new Gardien("dav k", "G", 5, 4, 6,0,0,0,0);
            Console.WriteLine(test);
            Console.WriteLine("--------Gardien cree-----------------------------------------");

            Joueur test2 = new JoueurDeSurface(test);
            Console.WriteLine(test2);
            Console.WriteLine("--------Gardien creation d'un jour de surface avec un gardien---------------");
        }
    }
}
