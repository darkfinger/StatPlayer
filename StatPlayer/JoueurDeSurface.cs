using System;

namespace StatPlayer
{
    class JoueurDeSurface:Joueur,IComparable
    {
        /// <summary>
        /// attribut declaration
        /// </summary>
        uint nombreDeMatch_;
        /// <summary>
        /// property for the nombreDeMatch att.
        /// </summary>
        public uint NombreDeMatch
        {
            get
            {
                return this.nombreDeMatch_;
            }
            set
            {
                if (value >= 0)//if the quantity is positive
                {
                    //chack if the format is in the correct form
                    try { this.nombreDeMatch_ = value; } catch (FormatException) { throw new ApplicationException("invalid format for NombreDeMatch"); }

                }
                else
                {
                    throw new ApplicationException("invalid format for NombreDeMatch");
                }
            }
        }
        /// <summary>
        /// attribut that compute the total score of an player
        /// </summary>
        public override float  Rendement
        {
            get
            {
                return this.NombreDeBut + this.NombreDePasse;
            }
        }
        /// <summary>
        /// copy constructeur of joueurDeSurface
        /// </summary>
        /// <param name="joueurDeSurface"></param>
        public JoueurDeSurface(JoueurDeSurface joueurDeSurface) : base(joueurDeSurface)
        {
            this.NombreDeMatch = joueurDeSurface.NombreDeMatch;
            if (this.NombreDeMatch == 0)
            {
                this.NombreDeBut = 0;
                this.NombreDePasse = 0;
            }
        }
        /// <summary>
        /// constructur inhereted from parent and additional param for nombredematch
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="position"></param>
        /// <param name="match"></param>
        /// <param name="but"></param>
        /// <param name="passe"></param>
        public JoueurDeSurface(String nomEquipe,string nom, string position, uint match, uint but, uint passe) : base(nomEquipe,nom, position, but, passe)
        {
            if (IsJoueurDeSurface(this))
            {
                this.NombreDeMatch = match;
                if (this.NombreDeMatch == 0)
                {
                    this.NombreDeBut = 0;
                    this.NombreDePasse = 0;
                }
            }
            else { throw new ApplicationException("only players with position diferent than G can be JoueurDesurface");}
            
        }
        /// <summary>
        /// toString ovverride to print out stat of an individual player
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            String details;
            details = this.Nom + " " + this.PostNom +" "+this.NomEquipe+ " " + this.Position + " "+this.NombreDeMatch 
                        +" |but: " + this.NombreDeBut + " |Passe: " + this.NombreDePasse + " |total:" +this.Rendement;
            return details;
        }
        public Boolean IsJoueurDeSurface(Joueur j)
        {
            if (!j.Position.ToUpper().Equals("G"))
            {
                return true;
            }
            else { return false; }
        }

        public int CompareTo(object obj)
        {
            if (!(obj is JoueurDeSurface))
            {
                throw new ArgumentException("L'objet n'est pas de la classe Etudiant");
            }
            JoueurDeSurface autreJoueur = obj as JoueurDeSurface;
            int comparaison = -(Rendement.CompareTo(autreJoueur.Rendement));
            if (comparaison == 0)
            {
                comparaison = -(NombreDeBut.CompareTo(autreJoueur.NombreDeBut));
            }
            if (comparaison == 0)
            {
                comparaison = (NombreDeMatch.CompareTo(autreJoueur.NombreDeMatch));
            }
            if (comparaison == 0)
            {
                comparaison = (Nom.CompareTo(autreJoueur.Nom));
            }
            if (comparaison == 0)
            {
                comparaison = (PostNom.CompareTo(autreJoueur.PostNom));
            }
            return comparaison;
        }
    }
}
