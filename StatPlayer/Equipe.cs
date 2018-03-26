using System;
using System.Collections.Generic;
using System.Linq;

namespace StatPlayer
{
    class Equipe
    {
        /// <summary>
        /// declaration de variable attribut
        /// </summary>
        string nom_;
        string ville_;
        string division_;
        string conference_;
        List<Joueur> listJoueurs_;

        /// <summary>
        /// Constructeur de la class sans list de joueur lors l'initialisation
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="Ville"></param>
        /// <param name="division"></param>
        /// <param name="conference"></param>
        public Equipe(String nom, String ville, String division , String conference)
        {
            this.Nom = nom;
            this.Ville = ville;
            this.Division = division;
            this.Conference = conference;
            this.ListJoueurs = new List<Joueur>();
        }
        /// <summary>
        /// deuxieme constructeur de la class avec list a l initialisation
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="Ville"></param>
        /// <param name="division"></param>
        /// <param name="conference"></param>
        /// <param name="listJoueur"></param>
        public Equipe(String nom, String ville, String division, String conference, List<Joueur> listJoueur)
        {
            this.Nom = nom;
            this.Ville = ville;
            this.Division = division;
            this.Conference = conference;
            this.ListJoueurs = listJoueur;
        }
        /// <summary>
        /// copy constructeur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="Ville"></param>
        /// <param name="division"></param>
        /// <param name="conference"></param>
        /// <param name="listJoueur"></param>
        public Equipe(Equipe e)
        {
            this.Nom = e.Nom;
            this.Ville = e.Ville;
            this.Division = e.Division;
            this.Conference = e.Conference;
            this.ListJoueurs = e.ListJoueurs;
        }
        /// <summary>
        /// propriete du non
        /// </summary>
        public string Nom
        {
            get
            {
                return nom_;
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value) && value is String)
                {
                    this.nom_ = value;
                }
                else
                {
                    throw new ApplicationException("Non de L'equipe n'est pas valide");
                }
            }

        }
        /// <summary>
        /// propriete de ville 
        /// </summary>
        public string Ville
        {
            get
            {
                return ville_;
            }

            private set
            {
                    if (!string.IsNullOrWhiteSpace(value) && value is String)
                    {
                        ville_ = value;
                    }
                    else
                    {
                        throw new ApplicationException("Non de La ville n'est pas valide");
                    }              
            }
        }
        /// <summary>
        /// propriete de l attribut division
        /// </summary>
        public string Division
        {
            get
            {
                return this.division_;
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value) && value is String)
                {
                    this.division_ = value;
                }
                else
                {
                    throw new ApplicationException("Non de la division n'est pas valide");
                }                
            }
        }
        /// <summary>
        /// propriete de l attribut conference
        /// </summary>
        public string Conference
        {
            get
            {
                return conference_;
            }

            private set
            {
                if (!string.IsNullOrWhiteSpace(value) && value is String)
                {
                    this.conference_ = value;
                }
                else
                {
                    throw new ApplicationException("Non de La conference n'est pas valide");
                }
                
            }
        }
        /// <summary>
        /// propriet de l attribut list joueur, elle est private car seul la class equipe decide d en affecter
        /// une list de joueur ou non, et cela e fera dans la methode SetListJoueur
        /// </summary>
        private List<Joueur> ListJoueurs
        {
            get
            {
                return listJoueurs_;
            }
            set
            {
                try { listJoueurs_ = value;} catch (Exception) { throw new ApplicationException("Incompatible list"); }                
            }
        }
        /// <summary>
        /// propriete indexe permetant d'avoir un joueur en particulier si l index exist dans la list
        /// le set est private car tout ajout d'un joueur se fait par la class dans la methode  AddJoueurToTheTeam()
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Joueur this[int index]
        {
            get {  try { return this.ListJoueurs[index]; }
                catch (IndexOutOfRangeException) {
                    throw new ApplicationException("Joueur n existe pas");
                }
            }
            private set
            {
                try { this.ListJoueurs.Add(value); }
                catch (Exception)
                {
                    throw new ApplicationException("Incompatible type, only joueur, joueurdesurface and gardien can be added to a team");
                }
            }
        }
        /// <summary>
        /// Methode permettant de retourner une copie de joueur qui sont de gardien
        /// </summary>
        /// <returns></returns>
        public List<Gardien> GetListGardien()
        {
            List<Gardien> listGardien = this.ListJoueurs.OfType<Gardien>().ToList();
            return listGardien;
        }
        /// <summary>
        /// Methode permetant de retourner un joueur Gardien dans l'index 
        /// de la list de gardien, si l index exist
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Gardien GetGardienAt(int index)
        {
            try
            {
                List<Gardien> listGardien = this.ListJoueurs.OfType<Gardien>().ToList();
                return listGardien[index];
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }
        }
        /// <summary>
        /// Methode permettant de retourner une copie de joueur qui sont de joueur de surface
        /// </summary>
        /// <returns></returns>
        public List<JoueurDeSurface> GetListJoueurDeSurface()
        {
            List<JoueurDeSurface> listJoueurDeSurface = this.ListJoueurs.OfType<JoueurDeSurface>().ToList();
            return listJoueurDeSurface;
        }
        /// <summary>
        /// Methode permetant de retourner un joueur de surface dans l'index 
        /// de la list de JoueurdeSurface, si l index exist
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public JoueurDeSurface GetJoueurDeSurfaceAt(int index)
        {
            try {List<JoueurDeSurface> listJoueurDeSurface = this.ListJoueurs.OfType<JoueurDeSurface>().ToList();
            return listJoueurDeSurface[index]; }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException();
            }            
        }
        /// <summary>
        /// affecte un list de joueur a l equipe
        /// </summary>
        /// <param name="listJoueur"></param>
        public void SetListJoueur(List<Joueur> listJoueur)
        {
            try
            { this.ListJoueurs = listJoueur; }
            catch (Exception)
            {
                throw new ApplicationException("list de joueur incompatible");            }
        }
        /// <summary>
        /// ajoute un nouveau joueur dans la list de jour de l equipe
        /// </summary>
        /// <param name="j"></param>
        public void AddJoueurToTheTeam(Joueur j)
        {
            try {this.ListJoueurs.Add(j); } catch (Exception)
            {
                throw new ApplicationException("imcompatible type a affecter dans la list de joueur de l equie");
            }
            
        }
    }
}