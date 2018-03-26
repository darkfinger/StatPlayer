using System;

namespace StatPlayer
{
    class JoueurDeSurface:Joueur
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
                    try { this.nombreDeMatch_ = value; } catch (FormatException) { throw new Exception(); }

                }
                else
                {
                    throw new Exception();
                }
            }
        }
        /// <summary>
        /// attribut that compute the total score of an player
        /// </summary>
        public uint Total
        {
            get
            {
                return this.NombreDeBut + this.NombreDePasse;
            }
        }
        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="joueur"></param>
        public JoueurDeSurface(Joueur joueur) : base(joueur)
        {
            if (joueur.Position.ToUpper().Equals("G"))
            {
                throw new ApplicationException("only players with position diferent the G can be JoueurDesurface");
            }
            this.NombreDeMatch = 0;
            this.NombreDeBut = 0;
            this.NombreDePasse = 0;            
        }
        /// <summary>
        /// copy constructeur with an additional param for the nombredematch 
        /// </summary>
        /// <param name="joueur"></param>
        /// <param name="match"></param>
        public JoueurDeSurface(Joueur joueur,uint match) : base(joueur)
        {
            if (joueur.Position.ToUpper().Equals("G"))
            {
                throw new ApplicationException("only players with position diferent the G can be JoueurDesurface");
            }
            this.NombreDeMatch = match;
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
        public JoueurDeSurface(string nom, string position, uint match, uint but, uint passe) : base(nom, position, but, passe)
        {
            if (position.ToUpper().Equals("G"))
            {
                throw new Exception();
            }
            this.NombreDeMatch = match;
            if (this.NombreDeMatch == 0)
            {
                this.NombreDeBut = 0;
                this.NombreDePasse = 0;
            }
        }
        /// <summary>
        /// toString ovverride to print out stat of an individual player
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            String details;
            details = this.Nom + " " + this.PostNom + " " + this.Position + " "+this.NombreDeMatch 
                        +" " + this.NombreDeBut + " " + this.NombreDePasse + " " +this.Total;
            return details;
        }
    }
}
