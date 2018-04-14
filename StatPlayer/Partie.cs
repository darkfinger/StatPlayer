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
                    //if we throw it, the program will stop after checking and not finding an accurate type at the first index 
                    if (value.Equals(type))
                    {
                        this.typeDePartie_ = value;
                    }
                    else
                    {
                        this.typeDePartie_ = 'R';//match Regulier par default
                    }
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
        /// Properti that return the JoueurDeSurface list of the game
        /// </summary>
        /// <returns></returns>
        public List<JoueurDeSurface> GetListJoueurDeSurface()
        {
            List<JoueurDeSurface> listJoueurDeSurface = this.ListjoueurDeLaPartie.OfType<JoueurDeSurface>().ToList();
            return listJoueurDeSurface;
        }
        /// <summary>
        /// Methode that retourn a general list of all playeur in the game
        /// </summary>
        /// <returns></returns>
        public List<Joueur> GetListJoueurEnGeneral()
        {
            List<Joueur> listJoueurEnGeneral = this.ListjoueurDeLaPartie;
            return listJoueurEnGeneral;
        }
        /// <summary>
        /// construtor
        /// </summary>
        /// <param name="equipe1">la premiere equipe</param>
        /// <param name="nombreButEq1">le nombre de but marquee</param>
        /// <param name="equipe2">2eme equipe</param>
        /// <param name="nombreButEq2">le nombre de but marquee de la 2eme equipe</param>
        /// <param name="typeDePartie">le type de parti</param>
        public Partie(Equipe equipe1, int nombreButEq1, Equipe equipe2, int nombreButEq2, char typeDePartie)
        {
            try
            {
            this.Equipe1 = equipe1;
            this.NombreButEq1 = nombreButEq1;
            this.Equipe2 = equipe2;
            this.NombreButEq2 = nombreButEq2;
            this.TypeDePartie = typeDePartie;
            this.listjoueurDeLaPartie_ = new List<Joueur>();
            }
            catch (Exception)
            {
                throw new ApplicationException("cant' creat a partie");
            }
            
        }
        /// <summary>
        /// ajoute un joueur dans la parti
        /// </summary>
        /// <param name="j"></param>
        public void AjouterJoueurDansLaListdeLaPartie(Joueur j)
        {
            this.listjoueurDeLaPartie_.Add(j);
        }
        /// <summary>
        /// determine le gagnant d'une partie
        /// </summary>
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