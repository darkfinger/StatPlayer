﻿using System;

namespace StatPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Joueur a = new Joueur("dav k", "c", 5, 4, 6);
            Console.WriteLine(a);
            Console.WriteLine("-------------------------------------------------");
            Joueur b = new Joueur("dav kapanga kap", "AG", 0, 4, 6);
            Console.WriteLine(b);
            Console.WriteLine("-------------------------------------------------");
            Joueur c = new Joueur("dav kan kan", "G", 5, 0, 0);
            Console.WriteLine(c);
            Console.WriteLine("-------------------------------------------------");
            Joueur d = new Joueur("dav kaz", "ad", 0, 4, 6);
            Console.WriteLine(d);
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
