using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatPlayer
{
    class Partie
    {
        /// <summary>
        /// a static readonly array considered as a constant array
        /// </summary>
        private static readonly char[] TYPEPARTIE = { 'R', 'P', 'F'};
        /// <summary>
        /// attribut declaration
        /// </summary>
        Equipe equipe1_;
        Equipe equipe2_;
        int nombreButEq1_;
        int nombreButEq2_;
        char typeDePartie_;
        List<Joueur> listjoueurDeLaPartie_;
        /// <summary>
        /// properti for Equipe1
        /// </summary>
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
                    throw new ApplicationException("incompatible format, only an Equipe object can be affected to the equipe attribut of class Partie");
                }   
            }
        }
        /// <summary>
        /// properti for equipe2
        /// </summary>
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
                    throw new ApplicationException("incompatible format, only an Equipe object can be affected to the equipe attribut of class Partie");
                }
            }
        }
        /// <summary>
        /// properti for NombreButEq1
        /// </summary>
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
                    try { this.nombreButEq1_ = value; } catch (FormatException) { throw new ApplicationException("invalid but format for the equipe 1"); }

                }
                else
                {
                    throw new Exception();
                }
            }
        }
        /// <summary>
        /// properti for NombreButEq2
        /// </summary>
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
                    throw new ApplicationException("invalid but format for the equipe 2");
                }
            }
        }
        /// <summary>
        /// properti for TypeDePartie
        /// </summary>
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
                    //if we throw it, the program will stop after checking and not finding an accurate type at the index 
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
                    throw new ApplicationException("Incompatible type de partie");
                }
            }
        }
        private List<Joueur> ListjoueurDeLaPartie
        {
            get
            {
                return this.listjoueurDeLaPartie_;
            }
            set
            {
                try { this.listjoueurDeLaPartie_ = value; } catch (Exception) { throw new ApplicationException("imcopatible list de jour for this game "); }
            }
        }      
        public Joueur this[int index]
        {
            get
            {
                // on retourne une copie de la tasse dans la liste, rendant impossible
                // d'atteindre la tasse originale qui se trouve dans la liste
                return new JoueurDeSurface(ListjoueurDeLaPartie[index]);
            }
        }

        /// <summary>
        /// Properti that return the gardien list of the game
        /// </summary>
        /// <returns></returns>
        public List<Gardien> ListGardien
        {
            get
            {
            List<Gardien> listGardien = this.ListjoueurDeLaPartie.OfType<Gardien>().ToList();
            return listGardien;
            }
        }
        /// <summary>
        /// properti that return a gardien of the game at the index, if index exist
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Gardien GetGardienAt(int index)
        {
            try
            {
                List<Gardien> listGardien = this.ListjoueurDeLaPartie.OfType<Gardien>().ToList();
                return listGardien[index];
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("there is no Gardien at this index that played the game");
            }
        }
        /// <summary>
        /// Properti that return the JoueurDeSurface list of the game
        /// </summary>
        /// <returns></returns>
        public List<JoueurDeSurface> GetListJoueurDeSurface()
        {
            List<JoueurDeSurface> listJoueurDeSurface = this.ListjoueurDeLaPartie.OfType<JoueurDeSurface>().ToList();
            return listJoueurDeSurface;
        }
        /// <summary>
        /// properti that return a JoueurDeSurface of the game at the index, if index exist
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public JoueurDeSurface GetJoueurDeSurfaceAt(int index)
        {
            try
            {
                List<JoueurDeSurface> listJoueurDeSurface = this.ListjoueurDeLaPartie.OfType<JoueurDeSurface>().ToList();
                return listJoueurDeSurface[index];
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("there is no JoueurDeSurface at this index that played the game");
            }
        }
        public String Winner
        {
            get
            {
                if (this.TypeDePartie.Equals('R') || this.TypeDePartie.Equals('P'))
                {
                    if (NombreButEq1 > NombreButEq2)
                    {
                        return this.Equipe1.Nom;
                    }
                    else
                    {
                        return this.Equipe2.Nom;
                    }
                }
                else
                {
                    return " ";
                }
                
            }
        }
    }
}