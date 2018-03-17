using System;
using System.Collections.Generic;

namespace StatPlayer
{
    class Partie
    {
        private static readonly char[] TYPEPARTIE = { 'R', 'P', 'F'};
        Equipe equipe1_;
        Equipe equipe2_;
        int nombreButEq1_;
        int nombreButEq2_;
        char typeDePartie_;
        List<Joueur> listjoueurClesDeLaPartie_;
        List<Joueur> listGardienClesDeLaPartie_;
        public Equipe Equipe1
        {
            get
            {
                return this.equipe1_;
            }
            set
            {
                try
                {
                this.equipe1_ = value; 
                }catch (Exception)
                {
                    throw new Exception();
                }   
            }
        }
        public Equipe Equipe2
        {
            get
            {
                return this.equipe2_;
            }
            set
            {
                try
                {
                    this.equipe2_ = value;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }
        public int NombreButEq1
        {
            get
            {
                return this.nombreButEq1_;
            }
            set
            {
                if (value >= 0)//if the passe is positive
                {
                    //chack if the format is in the correct form
                    try { this.nombreButEq1_ = value; } catch (FormatException) { throw new Exception(); }

                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public int NombreButEq2
        {
            get
            {
                return this.nombreButEq2_;
            }
            set
            {
                if (value >= 0)//if the passe is positive
                {
                    //chack if the format is in the correct form
                    try { this.nombreButEq2_ = value; } catch (FormatException) { throw new Exception(); }

                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public char TypeDePartie
        {
            get
            {
                return this.typeDePartie_; 
            }
            set
            {
                foreach (char type in TYPEPARTIE)
                {
                    //we cannot throw an Exception on an else, because we want to check that the value in every index of TYPEPARTIE
                    //if we throw it, the program will stop after checking the first index and not finding an accurate position
                    if (value.Equals(type))
                    {
                        this.typeDePartie_ = value;
                        break;//if we find one value that match on the TYPEPARTIE, we don't have to go all along.
                    }
                }
                //if the loop finds an accurate position then the attribut will be assigned, if it's still null 
                //it means it didn't found an accurate value, therefore we throw an error
                if (this.typeDePartie_ == '\0')
                {
                    throw new Exception();
                }
            }
        }
        private List<Joueur> ListjoueurClesDeLaPartie
        {
            get
            {
                return this.listjoueurClesDeLaPartie_;
            }
            set
            {
                try { this.listjoueurClesDeLaPartie_ = value; } catch (Exception) { throw new Exception(); }
            }
        }
        private List<Joueur> ListGardienClesDeLaPartie
        {
            get
            {
                return this.listGardienClesDeLaPartie_;
            }
            set
            {
                try { this.listGardienClesDeLaPartie_ = value; } catch (Exception) { throw new Exception(); }
            }
        }
        public Joueur this[int index]
        {
            get
            {
                // on retourne une copie de la tasse dans la liste, rendant impossible
                // d'atteindre la tasse originale qui se trouve dans la liste
                return new Joueur(ListjoueurClesDeLaPartie[index]);
            }
        }
        public Gardien this[short index]
        {            
            get
            {
                int i = index;
                // on retourne une copie de la tasse dans la liste, rendant impossible
                // d'atteindre la tasse originale qui se trouve dans la liste
                return new Gardien(ListGardienClesDeLaPartie[i]);
            }
        }
    }
}
