using System;

namespace StatPlayer
{
    class JoueurDeSurface:Joueur
    {

        uint nombreDeMatch_;
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
        public JoueurDeSurface(Joueur joueur) : base(joueur)
        {
            if (joueur.Position.ToUpper().Equals("G"))
            {
                throw new Exception();
            }
            this.NombreDeMatch = 0;
            this.NombreDeBut = 0;
            this.NombreDePasse = 0;            
        }
        public JoueurDeSurface(Joueur joueur,uint match) : base(joueur)
        {
            if (joueur.Position.ToUpper().Equals("G"))
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
    }
}
